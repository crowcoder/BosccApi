using BosccApi.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BosccApi.Controllers
{
    public class TokenController : Controller
    {
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Create(string username, string password)
        {
            if (ApiSecurity.AuthenticationIsValid(username, password))
            {
                return new ObjectResult(ApiSecurity.GenerateToken());
            }
            return BadRequest();
        }
    }
}
