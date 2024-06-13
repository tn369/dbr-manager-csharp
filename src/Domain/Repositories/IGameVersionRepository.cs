using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IGameVersionRepository : IRepository<Entities.GameVersion, GameVersionId> { }
}
