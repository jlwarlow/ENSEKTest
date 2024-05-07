using Dapper;
using Microsoft.Extensions.Configuration;

namespace Reading.Infrastructure
{
    public class ReadingRepository : BaseRepository, IReadingRepository
    {
        public ReadingRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Add(Entity.Reading reading)
        {
            using var con = CreateConnection();
            var result = await con.ExecuteAsync(
                "INSERT INTO Reading(AccountId, MeterReadingDateTime, MeterReadingValue) VALUES (@AccountId, @MeterReadingDateTime, @MeterReadingValue)",
                new
                {
                    reading.AccountId,
                    reading.MeterReadingDateTime,
                    reading.MeterReadingValue
                });
            return result;
        }

        public async Task<Entity.Reading?> GetLastReading(int accountId)
        {
            using var con = CreateConnection();
            var result = await con.QueryAsync<Entity.Reading>(
                "SELECT TOP 1 AccountId, MeterReadingDateTime, MeterReadingValue FROM Reading WHERE AccountId = @AccountId ORDER by MeterReadingDateTime DESC",
                new
                {
                    accountId
                });
            return result?.FirstOrDefault();
        }
    }
}
