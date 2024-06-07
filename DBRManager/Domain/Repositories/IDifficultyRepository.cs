using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IDifficultyRepository : IRepository<Difficulty, DifficultyId> { }
}
