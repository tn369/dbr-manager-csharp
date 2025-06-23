using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IPlayerScoreRepository : IRepository<PlayerScore, (PlayerId, MusicId, Difficulty, PlayAt)>
    {
        Task<PlayerScore?> GetByPlayerAndChartAsync(PlayerId playerId, int chartId);
        Task<IEnumerable<PlayerScore>> GetByPlayerIdAsync(PlayerId playerId);
        Task<IEnumerable<PlayerScore>> GetScoresByPlayerIdAsync(PlayerId playerId);
        Task<IEnumerable<PlayerScore>> GetScoresByMusicIdAsync(MusicId musicId);
    }
}
