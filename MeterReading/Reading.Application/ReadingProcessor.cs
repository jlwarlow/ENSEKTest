using Microsoft.Extensions.Logging;
using Reading.Infrastructure;

namespace Reading.Application
{
    public class ReadingProcessor : IReadingProcessor
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IReadingRepository _readingRepository;
        private readonly IReadingValidator _readingValidator;
        private readonly ILogger<ReadingProcessor> _logger;

        public ReadingProcessor(IAccountRepository accountRepository, IReadingRepository readingRepository, IReadingValidator readingValidator, ILogger<ReadingProcessor> logger)
        {
            _accountRepository = accountRepository;
            _readingRepository = readingRepository;
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
                        var lastReading = await _readingRepository.GetLastReading(reading!.AccountId);
                        if (lastReading == null || _readingValidator.NewReadingIsValid(reading, lastReading))
                        {
                            await _readingRepository.Add(reading);
                            processedCount++;
                        }
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
    }
}
