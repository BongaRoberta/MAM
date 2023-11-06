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

        public void Delete(int artistId)
        {
            _repo.Delete(artistId);
        }

        public List<MusicArtistInformation> GetAll()
        {
           return _repo.GetAll();
        }
    }
}
