using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IRivalRepository : IRepository<Rival, (PlayerId, PlayerId)> { }
}
