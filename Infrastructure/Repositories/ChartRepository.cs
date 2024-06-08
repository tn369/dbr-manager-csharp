using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class ChartRepository : Repository<Chart, MusicId>, IChartRepository
    {
        public ChartRepository(ApplicationDbContext context) : base(context) { }
    }
}