using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicArtistInfoController : ControllerBase
    {
        private static List<MusicArtistInformation> artists = new List<MusicArtistInformation>
            {
                new MusicArtistInformation {
                    IdNumber = 1,
                    FirstName = "Bonga",
                    LastName = "Mokoena",
                    PreferedName = "Roberta",
                    Title = "Miss"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<MusicArtistInformation>>> Get()
        {
            return Ok(artists);
        }

        [HttpPost]
        public async Task<ActionResult<List<MusicArtistInformation>>> AddArtist(MusicArtistInformation artistInformation)
        {
            artists.Add(artistInformation);
            return Ok(artists);
        }
    }
}
