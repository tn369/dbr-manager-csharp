using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class ClearLampRepository : Repository<ClearLamp, ClearLampId>, IClearLampRepository
    {
        public ClearLampRepository(ApplicationDbContext context) : base(context) { }
    }
}