using mamAPI.Interfaces;

namespace mamAPI
{
    public class DbConnectionStringProvider : IDbConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        public DbConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
            string serverName = Environment.MachineName;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            if (connectionString is not null)
            {
                connectionString = connectionString.Replace("{ServerName}", serverName);
            }

            return connectionString ?? string.Empty;
        }
    }
}
