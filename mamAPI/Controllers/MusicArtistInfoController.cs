﻿using mamAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
                },
                 new MusicArtistInformation {
                    IdNumber = 2,
                    FirstName = "Roberta",
                    LastName = "Mokoena",
                    PreferedName = "Bonga",
                    Title = "Ms"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<MusicArtistInformation>>> Get()
        {
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicArtistInformation>> Get(int id)
        {
            string connectionString = @"Data Source=KC-CEL23-02;Database=MusicArtistManagement;Integrated Security=false;User ID=FSA;Password=Password;TrustServerCertificate=True;";
            SqlConnection sqlConnection= new SqlConnection(connectionString);
            sqlConnection.Open();
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
            artist.Title = request.Title;

            return Ok(artists);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MusicArtistInformation>>> Delete(int id)
        {
            var artist = artists.Find(a => a.IdNumber == id);
            if (artist == null)
            {
                return BadRequest("Artist not in our Database");
            }

            artists.Remove(artist);
            return Ok(artists);
        }
    }
}
