using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicArtistInfoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MusicArtistInformation>>> Get()
        {
            var artists = new List<MusicArtistInformation>
            {
                new MusicArtistInformation {
                    IdNumber = 1,
                    FirstName = "Bonga",
                    LastName = "Mokoena",
                    PreferedName = "Roberta",
                    Title = "Miss"
                }
            };
            return Ok(artists);
        }
    }
}
