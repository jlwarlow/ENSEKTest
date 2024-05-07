using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Reading.Entity;
using System.Data;

namespace Reading.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Add(Entity.Reading reading)
        {
            throw new NotImplementedException();
        }
        public void Add(Account account)
        {
            throw new NotImplementedException();
        }

        private IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("MeterReadingsDBConnection"));
            return connection;
        }
    }
}
