using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class PlayerScoreRepository : Repository<PlayerScore, (PlayerId, MusicId, Difficulty, PlayAt)>, IPlayerScoreRepository
    {
        public PlayerScoreRepository(ApplicationDbContext context) : base(context) { }

        public Task DeleteAsync((PlayerId, MusicId, Difficulty, PlayAt) id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerScore> GetByIdAsync((PlayerId, MusicId, Difficulty, PlayAt) id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlayerScore>> GetScoresByMusicIdAsync(Guid musicId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlayerScore>> GetScoresByPlayerIdAsync(Guid playerId)
        {
            throw new NotImplementedException();
        }
    }
}