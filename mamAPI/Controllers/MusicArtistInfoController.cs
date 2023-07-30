using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicArtistInfoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = new List<MusicArtistInformation>
            {
                new MusicArtistInformation {IdNumber=1,  }
            };
        }
    }
}
