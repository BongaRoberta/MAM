using System.Data;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Dapper;
using mamAPI.Interfaces;
using mamAPI.Models;
using Microsoft.Data.SqlClient;

namespace mamAPI.Repository
{
    public class MusicArtistManagementRepository : IMusicArtistManagementRepository
    {
        private readonly IDbConnectionStringProvider _dbConnectionStringProvider;

        public MusicArtistManagementRepository(IDbConnectionStringProvider dbConnectionStringProvider)
        {
            _dbConnectionStringProvider = dbConnectionStringProvider;
        }

        public void AddNewArtist(MusicArtistInformation musicArtistInformation)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_InsertArtistInformation";

            var parameter = new DynamicParameters();
            parameter.Add("@IdNumber", musicArtistInformation.IdNumber);
            parameter.Add("@FirstName", musicArtistInformation.FirstName);
            parameter.Add("@StageName", musicArtistInformation.StageName);
            parameter.Add("@LastName", musicArtistInformation.LastName);
            parameter.Add("@Gender", musicArtistInformation.Gender);
            parameter.Add("@CityBased", musicArtistInformation.CityBased);
            parameter.Add("@ContactNumber", musicArtistInformation.ContactNumber);
            parameter.Add("@EmailAddress", musicArtistInformation.EmailAddress);
            parameter.Add("@InstagramHandle", musicArtistInformation.InstagramHandle);
            parameter.Add("@TikTokHandle", musicArtistInformation.TikTokHandle);
            parameter.Add("@MusicGenreStyle", musicArtistInformation.MusicGenreStyle);
            parameter.Add("@BriefArtistDescription", musicArtistInformation.BriefArtistDescription);
            parameter.Add("@PastPerformance", musicArtistInformation.PastPerformance);
            parameter.Add("@Age", GetAge(musicArtistInformation.IdNumber));

            dbConnection.Execute(query, parameter, commandType: CommandType.StoredProcedure);
        }

        public List<MusicArtistInformation> GetAllArtists()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_GetAllArtist";

            var allArtist = dbConnection.Query<MusicArtistInformation>(query).ToList();

            return allArtist;
        }

        public List<MusicArtistInformation> GetArtistById(int artistId)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_GetArtistInformationById";

            var parameter = new DynamicParameters();
            parameter.Add("@ArtistId", artistId);

            var artistById = dbConnection.Query<MusicArtistInformation>(query,parameter, commandType: CommandType.StoredProcedure).ToList();

            return artistById;
        }

        public void UpdateArtist(int artistId, MusicArtistInformation musicArtistInformation)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_UpdateArtistInformation";

            var parameter = new DynamicParameters();
            parameter.Add("@ArtistId", musicArtistInformation.ArtistId);
            parameter.Add("@StageName", musicArtistInformation.StageName);
            parameter.Add("@CityBased", musicArtistInformation.CityBased);
            parameter.Add("@ContactNumber", musicArtistInformation.ContactNumber);
            parameter.Add("@EmailAddress", musicArtistInformation.EmailAddress);
            parameter.Add("@InstagramHandle", musicArtistInformation.InstagramHandle);
            parameter.Add("@TikTokHandle", musicArtistInformation.TikTokHandle);
            parameter.Add("@MusicGenreStyle", musicArtistInformation.MusicGenreStyle);
            parameter.Add("@BriefArtistDescription", musicArtistInformation.BriefArtistDescription);
            parameter.Add("@PastPerformance", musicArtistInformation.PastPerformance);

            dbConnection.Execute(query, parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteArtist(int artistId)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_deleteArtist";

            var parameter = new { ArtistId = artistId };

            dbConnection.Execute(query, parameter, commandType: CommandType.StoredProcedure);
        }

        public List<MusicArtistInformation> SearchArtist(string searchTerm)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_SearchArtists";

            var parameter = new DynamicParameters();
            parameter.Add("@SearchTerm", searchTerm);

            var searchArtist = dbConnection.Query<MusicArtistInformation>(query, parameter, commandType: CommandType.StoredProcedure).ToList();

            return searchArtist;
        }

        public int GetAge(string IdNumber)
        {
            int age = 0;
            if (IdNumber != null)
            {
                string dateOfBirth = IdNumber.Substring(0, 6);
                
                if (DateTime.TryParseExact(dateOfBirth, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime birthdate))
                {
                    age = CalculateAge(birthdate);
                }
            }
            
            return age;
        }

        static int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public static bool IsValidIdNumber(string idNumber)
        {
            if (idNumber.Length != 13)
            {
                return false;
            }

            if (!Regex.IsMatch(idNumber, @"^\d{13}$"))
            {
                return false;
            }

            string birthdateString = idNumber.Substring(0, 6);
            if (!DateTime.TryParseExact(birthdateString, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime birthdate))
            {
                return false;
            }

            if (birthdate > DateTime.Now || birthdate.Year < 1800)
            {
                return false;
            }

            int checksum = int.Parse(idNumber[12].ToString());
            int sum = 0;

            for (int i = 0; i < 12; i++)
            {
                int digit = int.Parse(idNumber[i].ToString());

                if (i % 2 == 0)
                {
                    sum += digit;
                }
                else
                {
                    sum += digit * 2;
                    if (digit >= 5)
                    {
                        sum -= 9;
                    }
                }
            }

            int calculatedChecksum = (10 - (sum % 10)) % 10;

            return checksum == calculatedChecksum;
        }
    }
}
