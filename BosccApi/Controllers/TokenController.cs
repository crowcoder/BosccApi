using BosccApi.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BosccApi.Controllers
{
    public class TokenController : Controller
    {
        private readonly ILogger _logger;

        public TokenController(ILogger<TokenController> logger)
        {
            _logger = logger;
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Create(string username, string password)
        {
            _logger.LogInformation("Creating Token", username, password);

            if (ApiSecurity.AuthenticationIsValid(username, password))
            {
                return new ObjectResult(ApiSecurity.GenerateToken());
            }
            return BadRequest();
        }
    }
}
