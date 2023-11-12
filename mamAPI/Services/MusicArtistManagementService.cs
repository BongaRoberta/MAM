using mamAPI.Interfaces;
using mamAPI.Models;
using mamAPI.Repository;

namespace mamAPI.Services
{
    public class MusicArtistManagementService : IMusicArtistManagementService
    {
        private readonly IMusicArtistManagementRepository _repo;

        public MusicArtistManagementService(IMusicArtistManagementRepository repo)
        {
            _repo = repo;
        }

        public void AddNewArtist(MusicArtistInformation musicArtistInformation)
        {
            musicArtistInformation.Age = GetAge(musicArtistInformation.IdNumber);
            _repo.AddNewArtist(musicArtistInformation);
        }

        public List<MusicArtistInformation> GetAllArtists()
        {
            return _repo.GetAllArtists();
        }

        public List<MusicArtistInformation> GetArtistById(int artistId)
        {
            return _repo.GetArtistById(artistId);
        }

        public void DeleteArtist(int artistId)
        {
            _repo.DeleteArtist(artistId);
        }

        public void UpdateArtistInformation(int artistId, MusicArtistInformation musicArtistInformation)
        {
            _repo.UpdateArtist(artistId, musicArtistInformation);
        }

        public List<MusicArtistInformation> SearchArtist(string searchTerm)
        {
            return _repo.SearchArtist(searchTerm);
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
    }
}
