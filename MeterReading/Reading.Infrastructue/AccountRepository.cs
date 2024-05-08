using Dapper;
using Microsoft.Extensions.Configuration;
using Reading.Entity;

namespace Reading.Infrastructure
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Add(Account account)
        {
            using var con = CreateConnection();
            var result = await con.ExecuteAsync(
                "INSERT INTO Account(AccountId, FirstName, LastName) VALUES (@AccountId, @FirstName, @LastName)",
                new
                {
                    account.AccountId,
                    account.FirstName,
                    account.LastName
                });
            return result;
        }

        public async Task<Account?> Get(int accountId)
        {
            using var con = CreateConnection();
            var result = await con.QueryAsync<Account>(
                "SELECT AccountId, FirstName, LastName FROM Account WHERE AccountId = @AccountId",
                new
                {
                    accountId
                });
            return result.FirstOrDefault();
        }
    }
}
