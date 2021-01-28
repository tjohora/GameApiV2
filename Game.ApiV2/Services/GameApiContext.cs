using Game.ApiV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Services
{
    public class GameApiContext : DbContext
    {
        public GameApiContext(DbContextOptions<GameApiContext> options) : base(options)
        {

        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
