using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IPlayerScoreRepository : IRepository<PlayerScore, (PlayerId, MusicId, DifficultyId, PlayAt)>
    {
        Task<IEnumerable<PlayerScore>> GetScoresByPlayerIdAsync(Guid playerId);
        Task<IEnumerable<PlayerScore>> GetScoresByMusicIdAsync(Guid musicId);
    }
}
