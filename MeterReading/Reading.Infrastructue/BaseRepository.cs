using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Reading.Infrastructure
{
    public class BaseRepository
    {
        protected IConfiguration Configuration { get; }

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected IDbConnection CreateConnection()
        {
            var connectionString = Configuration.GetConnectionString("MeterReadingsDBConnection");
            var connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
