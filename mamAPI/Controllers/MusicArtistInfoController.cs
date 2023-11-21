using mamAPI.Models;
using mamAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace mamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicArtistInfoController : ControllerBase
    {
        private readonly IMusicArtistManagementService _musicArtistManagement;
        public MusicArtistInfoController(IMusicArtistManagementService musicArtistManagementService)
        {
            _musicArtistManagement = musicArtistManagementService;
        }

        [HttpPost]
        public ActionResult<List<MusicArtistInformation>> AddArtistInformation(MusicArtistInformation musicArtistInformation)
        {
            _musicArtistManagement.AddNewArtist(musicArtistInformation);
            return Ok(musicArtistInformation);
        }

        [HttpGet]
        public async Task<ActionResult<List<MusicArtistInformation>>> Get()
        {
            var artists = _musicArtistManagement.GetAllArtists();
            var serializedArtistInfo = System.Text.Json.JsonSerializer.Serialize(new { data = artists });

            return Ok(serializedArtistInfo);
        }

        [HttpGet("{artistId}")]
        public async Task<ActionResult<MusicArtistInformation>> GetArtistById(int artistId)
        {
            var artist = _musicArtistManagement.GetArtistById(artistId);
            var serializedArtistInfo = System.Text.Json.JsonSerializer.Serialize(new { data = artist });

            return Ok(serializedArtistInfo);
        }

        [HttpGet("searchTerm")]
        public async Task<ActionResult<List<MusicArtistInformation>>> SearchArtist(string searchTerm)
        {
            var artists = _musicArtistManagement.SearchArtist(searchTerm);
            var serializedArtistInfo = System.Text.Json.JsonSerializer.Serialize(new { data = artists });

            return Ok(serializedArtistInfo);
        }

        [HttpPut]
        public ActionResult UpdateArtistInformation(int artistId, [FromBody] object musicArtistInformation)
        {
            if (artistId <= 0)
            {
                return BadRequest(new { message = "Artist does not exist" });
            }

            var jsonString = musicArtistInformation.ToString()??string.Empty;
            var artistInfo = JsonConvert.DeserializeObject<MusicArtistInformation>(jsonString);

            artistInfo.ArtistId = artistId;
            _musicArtistManagement.UpdateArtistInformation(artistId, artistInfo);

            return Ok(new { message = "Artist information updated" });
            //https://localhost:7263/api/MusicArtistInfo?artistId=((state.updateArtist.artistRecord.ArtistId))
        }

        [HttpDelete]
        public ActionResult DeleteArtistInformation(int artistId)
        {
            if (artistId <= 0)
            {
                return BadRequest(new { message = "Artist information does not exist" });
            }

            _musicArtistManagement.DeleteArtist(artistId);

            return Ok(new { message = "Artist information deleted" });
        }
    }
}
