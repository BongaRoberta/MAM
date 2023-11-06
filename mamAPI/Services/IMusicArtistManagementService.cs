using mamAPI.Models;

namespace mamAPI.Services
{
    public interface IMusicArtistManagementService
    {
        List<MusicArtistInformation> GetAll();
        void Delete(int artistId);

    }
}
