using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IVersionRepository : IRepository<Entities.Version, VersionId> { }
}
