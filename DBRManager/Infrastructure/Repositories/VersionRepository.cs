using Domain.Repositories;
using Domain.ValueObjects;
using Version = Domain.Entities.Version;

namespace Infrastructure.Repositories
{
    public class VersionRepository : Repository<Version, VersionId>, IVersionRepository
    {
        public VersionRepository(ApplicationDbContext context) : base(context) { }
    }
}