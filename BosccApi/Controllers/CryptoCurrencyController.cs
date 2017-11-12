using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BosccApi.Models;
using BosccApi.Data;

namespace BosccApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CryptoCurrency")]
    public class CryptoCurrencyController : Controller
    {
        private readonly PostsContext _ctx;

        public CryptoCurrencyController(PostsContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CryptoCurrency item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _ctx.CryptoCurrencies.Add(item);
            await _ctx.SaveChangesAsync();

            return Ok();

        }

    }
}