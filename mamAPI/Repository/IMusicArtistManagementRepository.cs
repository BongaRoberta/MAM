using mamAPI.Models;

namespace mamAPI.Repository
{
    public interface IMusicArtistManagementRepository
    {
        List<MusicArtistInformation> GetAll();
        void Delete(int artistId);
    }
}
