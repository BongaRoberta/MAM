using mamAPI.Models;

namespace mamAPI.Repository
{
    public interface IMusicArtistManagementRepository
    {
        List<MusicArtistInformation> GetAllArtists();
        void UpdateArtist(int artistId);
        void DeleteArtist(int artistId);
    }
}
