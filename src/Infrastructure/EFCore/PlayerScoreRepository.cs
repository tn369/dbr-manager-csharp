using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PlayerScoreRepository : Repository<PlayerScore, (PlayerId, MusicId, Difficulty, PlayAt)>, IPlayerScoreRepository
    {
        public PlayerScoreRepository(ApplicationDbContext context) : base(context) { }

        async Task IRepository<PlayerScore, (PlayerId, MusicId, Difficulty, PlayAt)>.DeleteAsync((PlayerId, MusicId, Difficulty, PlayAt) id)
        {
            var entity = await ((IRepository<PlayerScore, (PlayerId, MusicId, Difficulty, PlayAt)>)this).GetByIdAsync(id);
            if (entity != null)
            {
                _context.PlayerScores.Remove(entity);
            }
        }

        async Task<PlayerScore> IRepository<PlayerScore, (PlayerId, MusicId, Difficulty, PlayAt)>.GetByIdAsync((PlayerId, MusicId, Difficulty, PlayAt) id)
        {
            return await _context.PlayerScores.FirstOrDefaultAsync(ps =>
                ps.PlayerId == id.Item1 &&
                ps.MusicId == id.Item2 &&
                ps.Difficulty == id.Item3 &&
                ps.PlayAt == id.Item4);
        }

        public async Task<IEnumerable<PlayerScore>> GetScoresByMusicIdAsync(MusicId musicId)
        {
            return await _context.PlayerScores
                .Where(ps => ps.MusicId == musicId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerScore>> GetScoresByPlayerIdAsync(PlayerId playerId)
        {
            return await _context.PlayerScores
                .Where(ps => ps.PlayerId == playerId)
                .ToListAsync();
        }
    }
}