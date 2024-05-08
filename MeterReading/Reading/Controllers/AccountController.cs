using System.Text;
using Microsoft.AspNetCore.Mvc;
using Reading.Application;

namespace Reading.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountProcessor _processor;

        public AccountController(ILogger<AccountController> logger, IAccountProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [HttpPost]
        [Consumes("text/plain")]
        public async Task Seed()
        {
            try
            {
                using var reader = new StreamReader(Request.Body, Encoding.UTF8);
                var csv = await reader.ReadToEndAsync();
                await _processor.Seed(csv);
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
