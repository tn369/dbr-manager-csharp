using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.EFCore
{
    public class PlayerRepository : Repository<Player, PlayerId>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context) { }
    }
}