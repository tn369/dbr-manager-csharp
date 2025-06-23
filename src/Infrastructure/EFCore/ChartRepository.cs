using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.EFCore
{
    public class ChartRepository : Repository<Chart, int>, IChartRepository
    {
        public ChartRepository(ApplicationDbContext context) : base(context) { }
    }
}