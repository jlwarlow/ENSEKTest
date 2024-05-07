using Reading.Infrastructure;

namespace Reading.Application
{
    public class Processor : IProcessor
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IReadingRepository _readingRepository;

        public Processor(IAccountRepository accountRepository, IReadingRepository readingRepository)
        {
            _accountRepository = accountRepository;
            _readingRepository = readingRepository;
        }

        public int ProcessCSV(string csv)
        {
            throw new NotImplementedException();
        }
    }
}
