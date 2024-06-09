using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GameVersion = Domain.Entities.GameVersion;

namespace Infrastructure.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Chart> Charts { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerScore> PlayerScores { get; set; }
        public DbSet<Rival> Rivals { get; set; }
        public DbSet<GameVersion> GameVersions { get; set; }
    }
}
