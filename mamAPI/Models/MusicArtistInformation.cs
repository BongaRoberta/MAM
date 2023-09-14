namespace mamAPI.Models;

public class MusicArtistInformation
{
    public int ArtistId { get; set; }
    public string IdNumber { get; set; }
    public string FirstName { get; set; }
    public string StageName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string CityBased { get; set; }
    public string ContactNumber { get; set; }
    public string EmailAddress { get; set; }
    public string InstagramHandle { get; set; }
    public string TikTokHandle { get; set; }
    public string MusicGenreStyle { get; set; }
    public string BriefArtistDescription { get; set; }
    public string PastPerformance { get; set; }
    public byte[] Photograph { get; set; }
}

