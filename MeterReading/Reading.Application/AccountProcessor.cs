using Microsoft.Extensions.Logging;

namespace Reading.Application
{
    public class AccountProcessor : IAccountProcessor
    {
        private readonly ILogger<AccountProcessor> _logger;

        public AccountProcessor(ILogger<AccountProcessor> logger)
        {
            _logger = logger;
        }

        public Task Seed(string csv)
        {
            throw new NotImplementedException();
        }
    }
}
