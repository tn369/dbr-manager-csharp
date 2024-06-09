using Domain.Repositories;
using Domain.ValueObjects;
using GameVersion = Domain.Entities.GameVersion;

namespace Infrastructure.Repositories
{
    public class GameVersionRepository : Repository<GameVersion, GameVersionId>, IGameVersionRepository
    {
        public GameVersionRepository(ApplicationDbContext context) : base(context) { }
    }
}