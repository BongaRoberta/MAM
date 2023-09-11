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
            var artists = _musicArtistManagement.GetAll();
            return Ok(artists);
        }

       /* [HttpGet("{id}")]
        public async Task<ActionResult<MusicArtistInformation>> Get(string id)
        {
            var artist = artists.Find(a => a.IdNumber == id);
            if (artist == null)
            {
                return BadRequest("Artist not in our Database");
            }
               
            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<List<MusicArtistInformation>>> AddArtist(MusicArtistInformation artistInformation)
        {
            artists.Add(artistInformation);
            return Ok(artists);
        }

        [HttpPut]
        public async Task<ActionResult<List<MusicArtistInformation>>> UpdateArtist(MusicArtistInformation request)
        {
            var artist = artists.Find(a => a.IdNumber == request.IdNumber);
            if (artist == null)
            {
                return BadRequest("Artist not in our Database");
            }

            artist.FirstName = request.FirstName;
            artist.LastName = request.LastName;
            artist.PreferedName = request.PreferedName;

            return Ok(artists);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MusicArtistInformation>>> Delete(string id)
        {
            var artist = artists.Find(a => a.IdNumber == id);
            if (artist == null)
            {
                return BadRequest("Artist not in our Database");
            }

            artists.Remove(artist);
            return Ok(artists);
        } */
    }
}
 