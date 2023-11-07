using System.Data;
using Dapper;
using mamAPI.Interfaces;
using mamAPI.Models;
using Microsoft.Data.SqlClient;

namespace mamAPI.Repository
{
    public class MusicArtistManagementRepository : IMusicArtistManagementRepository
    {
        private readonly IDbConnectionStringProvider _dbConnectionStringProvider;

        public MusicArtistManagementRepository(IDbConnectionStringProvider dbConnectionStringProvider)
        {
            _dbConnectionStringProvider = dbConnectionStringProvider;
        }

        public void Delete(int artistId)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_deleteArtist";

            var parameter = new { ArtistId = artistId };

            dbConnection.Execute(query, parameter, commandType: CommandType.StoredProcedure);

        }

        public List<MusicArtistInformation> GetAll()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "sp_GetAllArtist";

            var allArtist = dbConnection.Query<MusicArtistInformation>(query).ToList();

            return allArtist;
        }
    }
}
