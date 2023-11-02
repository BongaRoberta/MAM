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
        public List<MusicArtistInformation> GetAll()
        {
            using System.Data.IDbConnection dbConnection = new SqlConnection(_dbConnectionStringProvider.GetConnectionString());

            const string query = "EXEC dbo.sp_GetAll";

            var something = dbConnection.Query<MusicArtistInformation>(query).ToList();

            return something;
        }
    }
}
