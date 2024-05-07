using Microsoft.AspNetCore.Mvc;
using Reading.Application;

namespace Reading.API.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReading : ControllerBase
    {
        private readonly ILogger<MeterReading> _logger;
        private readonly IProcessor _processor;

        public MeterReading(ILogger<MeterReading> logger, IProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [HttpGet]
        public async Task<string> Hello()
        {
            return await Task.FromResult<string>("Hello");
        }

        [HttpPost]
        public int Process(string csv)
        {
            throw new NotImplementedException();
        }
    }
}
