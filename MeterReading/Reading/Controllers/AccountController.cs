using Microsoft.AspNetCore.Mvc;
using Reading.Application;

namespace Reading.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task Seed([FromBody] string csv)
        {
            try
            {
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
