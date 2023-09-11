namespace mamAPI.Models;

public class MusicArtistInformation
{
    public int artist_id { get; set; }
    public string? id_number { get; set; }
    public string? first_name { get; set; }
    public string? stage_name { get; set; }
    public string? last_name { get; set; }
    public string? gender { get; set; }
    public string? city_based { get; set; }
    public string? contact_number { get; set; }
    public string? email_address { get; set; }
    public string? instagram_handle { get; set; }
    public string? tiktok_handle { get; set; }
    public string? music_genre_style { get; set; }
    public string? brief_artist_description { get; set; }
    public string? past_perfomance { get; set; }
    public byte[]? photograph { get; set; }
}

