using System.Data;
using System.Reflection.Metadata;
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
    }
}
