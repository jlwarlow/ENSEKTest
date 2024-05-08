using Microsoft.AspNetCore.Mvc;
using Reading.Application;

namespace Reading.API.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReading : ControllerBase
    {
        private readonly ILogger<MeterReading> _logger;
        private readonly IReadingProcessor _readingProcessor;

        public MeterReading(ILogger<MeterReading> logger, IReadingProcessor readingProcessor)
        {
            _logger = logger;
            _readingProcessor = readingProcessor;
        }

        [HttpGet]
        public async Task<string> Hello()
        {
            try
            {
                return await Task.FromResult<string>("Hello");
            }
            catch (Exception e)
            {
                var message = $"Exception in MeterReading.Hello : {e.Message}";
                _logger.LogError(message);
                throw;
            }
        }

        [HttpPost]
        public int Process(string csv)
        {
            throw new NotImplementedException();
        }
    }
}
