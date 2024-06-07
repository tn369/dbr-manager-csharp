using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class RivalRepository : Repository<Rival, (PlayerId, PlayerId)>, IRivalRepository
    {
        public RivalRepository(ApplicationDbContext context) : base(context) { }
    }
}