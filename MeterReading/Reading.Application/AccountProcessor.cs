using Azure.Identity;
using Microsoft.Extensions.Logging;
using Reading.Infrastructure;

namespace Reading.Application
{
    public class AccountProcessor : IAccountProcessor
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountValidator _accountValidator;
        private readonly ILogger<AccountProcessor> _logger;

        public AccountProcessor(IAccountRepository accountRepository, IAccountValidator accountValidator, ILogger<AccountProcessor> logger)
        {
            _accountRepository = accountRepository;
            _accountValidator = accountValidator;
            _logger = logger;
        }

        public async Task Seed(string csv)
        {
            var lines = csv.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var error = _accountValidator.Validate(line, out var account);
                if (error == null)
                {
                    
                    var existingAccount = await _accountRepository.Get(account!.AccountId);
                    if (existingAccount == null)
                    {
                        await _accountRepository.Add(account!);
                    }
                }
                else
                {
                    _logger.LogDebug($"Account Processor Seed failed to process line : {error}");
                }
            }
        }
    }
}
