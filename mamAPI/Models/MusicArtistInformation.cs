namespace mamAPI.Models
{
    public class MusicArtistInformation
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string PreferedName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CityBased { get; set; }
        //public string CountryBased { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string InstagramHandle { get; set; }
        public string TikTokHandle { get; set;}
        public string Genre { get; set; }
        public string Description { get; set; }
        public string PastPerfomance { get; set; }
        public byte[] ArtisttPhoto { get; set;}

    }
}
