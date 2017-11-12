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
        public async Task<IActionResult> Post([FromBody]List<CryptoCurrency> items)
        {
            if (items == null)
            {
                return BadRequest();
            }

            _ctx.CryptoCurrencies.AddRange(items);
            await _ctx.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var currency = _ctx.CryptoCurrencies.Find(id);
            if (currency != null)
            {
                return Ok(currency);
            }

            return NotFound(id);
        }
    }
}