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

        [HttpPost]
        public int Process(string csv)
        {
            throw new NotImplementedException();
        }
    }
}
