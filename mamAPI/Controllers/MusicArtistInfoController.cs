using mamAPI.Models;
using mamAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


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

        [HttpGet]
        public async Task<ActionResult<List<MusicArtistInformation>>> Get()
        {
            var artists = _musicArtistManagement.GetAllArtists();
            var serializedArtistInfo = System.Text.Json.JsonSerializer.Serialize(new { data = artists });

            return Ok(serializedArtistInfo);
        }

        [HttpPut]
        public ActionResult UpdateArtistInformation(int artistId)
        {
            if (artistId <= 0)
            {
                return BadRequest(new { message = "Artist does not exist" });
            }

            _musicArtistManagement.UpdateArtistInformation(artistId);

            return Ok(new { message = "Artist information updated" });
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
