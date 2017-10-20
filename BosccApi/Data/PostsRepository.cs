using BosccApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BosccApi.Data
{
    public class PostsContext : DbContext
    {
        public PostsContext(DbContextOptions<PostsContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
