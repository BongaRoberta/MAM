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

        public List<MusicArtistInformation> GetAllArtists()
        {
            return _repo.GetAllArtists();
        }

        public void DeleteArtist(int artistId)
        {
            _repo.DeleteArtist(artistId);
        }

        public void UpdateArtistInformation(int artistId)
        {
            _repo.UpdateArtist(artistId);
        }
    }
}
