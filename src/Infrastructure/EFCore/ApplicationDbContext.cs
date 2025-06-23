using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GameVersion = Domain.Entities.GameVersion;

namespace Infrastructure.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Chart> Charts { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerScore> PlayerScores { get; set; }
        public DbSet<GameVersion> GameVersions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerScore>()
                .HasKey(ps => new { ps.PlayerId, ps.MusicId, ps.Difficulty, ps.PlayAt });
        }
    }
}
