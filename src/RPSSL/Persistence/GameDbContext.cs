using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class GameDbContext : DbContext, IGameDbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Choise> Choises { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Scoreboard> Scoreboards { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
