using mamAPI.Models;

namespace mamAPI.Services
{
    public interface IMusicArtistManagementService
    {
        void AddNewArtist(MusicArtistInformation musicArtistInformation);
        List<MusicArtistInformation> GetAllArtists();
        List<MusicArtistInformation> GetArtistById(int artistId);
        List<MusicArtistInformation> SearchArtist(string searchTerm);
        void DeleteArtist(int artistId);
        void UpdateArtistInformation(int artistId, MusicArtistInformation musicArtistInformation);
    }
}
