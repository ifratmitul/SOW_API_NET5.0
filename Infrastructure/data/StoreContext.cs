using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { set; get; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<TournamentAward> TAward { get; set; }
        public DbSet<General> Stories { get; set; }
    }
}