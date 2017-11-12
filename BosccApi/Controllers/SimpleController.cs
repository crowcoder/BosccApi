using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BosccApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Simple")]
    public class SimpleController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(new { ID = id, TimeStamp = DateTimeOffset.Now });
        }
    }
}