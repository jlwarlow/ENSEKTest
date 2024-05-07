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
                "INSERT INTO Account(AccountId, FirstName, Surname) VALUES (@AccountId, @FirstName, @Surname) EXCEPT SELECT AccountId, Firstname, Surname FROM Account WHERE AccountId = @AccountId",
                new
                {
                    account.AccountId,
                    account.FirstName,
                    account.LastName
                });
            return result;
        }
        
    }
}
