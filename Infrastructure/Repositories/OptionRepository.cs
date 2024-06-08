using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class OptionRepository : Repository<Option, OptionId>, IOptionRepository
    {
        public OptionRepository(ApplicationDbContext context) : base(context) { }
    }
}