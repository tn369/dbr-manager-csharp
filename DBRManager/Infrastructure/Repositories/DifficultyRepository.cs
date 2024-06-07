using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class DifficultyRepository : Repository<Difficulty, DifficultyId>, IDifficultyRepository
    {
        public DifficultyRepository(ApplicationDbContext context) : base(context) { }
    }
}