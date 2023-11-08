using mamAPI.Models;

namespace mamAPI.Services
{
    public interface IMusicArtistManagementService
    {
        List<MusicArtistInformation> GetAllArtists();
        void DeleteArtist(int artistId);
        void UpdateArtistInformation(int artistId);
    }
}
