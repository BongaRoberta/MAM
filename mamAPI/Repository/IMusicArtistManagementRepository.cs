using mamAPI.Models;

namespace mamAPI.Repository
{
    public interface IMusicArtistManagementRepository
    {
        void AddNewArtist(MusicArtistInformation musicArtistInformation);
        List<MusicArtistInformation> GetAllArtists();
        List<MusicArtistInformation> GetArtistById(int artistId);
        List<MusicArtistInformation> SearchArtist(string searchTerm);
        void UpdateArtist(int artistId, MusicArtistInformation musicArtistInformation);
        void DeleteArtist(int artistId);
        

    }
}
