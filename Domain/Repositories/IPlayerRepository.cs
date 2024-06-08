using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IPlayerRepository : IRepository<Player, PlayerId> { }
}
