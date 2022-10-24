using System.Threading.Tasks;
using System.Threading;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IGameDbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Choise> Choises { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Scoreboard> Scoreboards { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
