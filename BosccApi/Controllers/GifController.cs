using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BosccApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Gif")]
    public class GifController : Controller
    {
        [HttpGet]
        public async Task<FileResult> Get()
        {
            var filepath = $"Assets/giphy.gif";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "image/gif", "giphy.gif");
        }
    }
}