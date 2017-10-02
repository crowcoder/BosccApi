using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BosccApi.Models;
using BosccApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace BosccApi.Controllers
{    
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly PostsContext _ctx;

        public PostsController(PostsContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            var thePosts = _ctx.Posts;
            return thePosts;
        }

        [Authorize]
        [HttpGet("{id}", Name ="GetPost")]
        public IActionResult GetById(int id)
        {
            var post = _ctx.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return new ObjectResult(post);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Post item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _ctx.Posts.Add(item);
            await _ctx.SaveChangesAsync();

            return CreatedAtRoute("GetPost", new { id = item.Id }, item);
            
        }
    }
}
