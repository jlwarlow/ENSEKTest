using Microsoft.AspNetCore.Mvc;
using Reading.Application;
using System.Text;

namespace Reading.API.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReadingController : ControllerBase
    {
        private readonly ILogger<MeterReadingController> _logger;
        private readonly IReadingProcessor _readingProcessor;

        public MeterReadingController(ILogger<MeterReadingController> logger, IReadingProcessor readingProcessor)
        {
            _logger = logger;
            _readingProcessor = readingProcessor;
        }

        [HttpPost]
        public async Task<int> Process()
        {
            try
            {
                using var reader = new StreamReader(Request.Body, Encoding.UTF8);
                var csv = await reader.ReadToEndAsync();
                return await _readingProcessor.ProcessCSV(csv);
            }
            catch (Exception e)
            {
                var message = $"Exception in AccountController:Seed {e.Message}";
                _logger.LogDebug(message);
                throw;
            }
        }
    }
}
