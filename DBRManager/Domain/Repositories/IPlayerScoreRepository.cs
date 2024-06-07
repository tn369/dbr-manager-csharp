using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IPlayerScoreRepository : IRepository<PlayerScore, (PlayerId, MusicId, DifficultyId)> { }
}
