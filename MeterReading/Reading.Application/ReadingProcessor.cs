using Microsoft.Extensions.Logging;
using Reading.Infrastructure;

namespace Reading.Application
{
    public class ReadingProcessor : IReadingProcessor
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IReadingRepository _readingRepository;
        private readonly IAccountValidator _accountValidator;
        private readonly IReadingValidator _readingValidator;
        private readonly ILogger<ReadingProcessor> _logger;

        public ReadingProcessor(IAccountRepository accountRepository, IReadingRepository readingRepository,
            IAccountValidator accountValidator, IReadingValidator readingValidator, ILogger<ReadingProcessor> logger)
        {
            _accountRepository = accountRepository;
            _readingRepository = readingRepository;
            _accountValidator = accountValidator;
            _readingValidator = readingValidator;
            _logger = logger;
        }

        public async Task<int> ProcessCSV(string csv)
        {
            var lines = csv.Split(Environment.NewLine);
            var processedCount = 0;
            foreach (var line in lines)
            {
                var error = _readingValidator.Validate(line, out var reading);
                if (string.IsNullOrEmpty(error))
                {
                    var account = await _accountRepository.Get(reading!.AccountId);
                    if (account != null)
                    {
                        processedCount++;
                    }
                    else
                    {
                        _logger.LogDebug($"Invalid account with AccountId ({reading.AccountId})");
                    }
                }
                else
                {
                    _logger.LogDebug(error);
                }
            }

            return processedCount;
        }

        public async Task<int> SeedAccounts(string csv)
        {
            var lines = csv.Split(Environment.NewLine);
            var processedCount = 0;
            foreach (var line in lines)
            {
                var error = _accountValidator.Validate(line, out var account);
                if (string.IsNullOrEmpty(error))
                {
                    await _accountRepository.Add(account!);
                    processedCount++;
                }
                else
                {
                    _logger.LogDebug($"Error validating account {error}");
                }
            }

            return processedCount;
        }
    }
}
