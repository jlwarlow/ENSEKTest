using Microsoft.AspNetCore.Mvc;

namespace Reading.API.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReading : ControllerBase
    {
        private readonly ILogger<MeterReading> _logger;

        public MeterReading(ILogger<MeterReading> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public int Process(string csv)
        {
            throw new NotImplementedException();
        }
    }
}
