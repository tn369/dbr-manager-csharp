using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    public class PlayerScoreRepository : IPlayerScoreRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerScoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerScore>> GetAllAsync()
        {
            return await _context.PlayerScores.ToListAsync();
        }

        public async Task<PlayerScore?> GetByIdAsync((PlayerId, MusicId, Difficulty, PlayAt) id)
        {
            return await _context.PlayerScores.FirstOrDefaultAsync(ps =>
                ps.PlayerId == id.Item1 &&
                ps.MusicId == id.Item2 &&
                ps.Difficulty == id.Item3 &&
                ps.PlayAt == id.Item4);
        }

        public async Task<PlayerScore?> GetByPlayerAndChartAsync(PlayerId playerId, int chartId)
        {
            return await _context.PlayerScores.FirstOrDefaultAsync(ps =>
                ps.PlayerId == playerId && ps.MusicId.Value == chartId);
        }

        public async Task<IEnumerable<PlayerScore>> GetByPlayerIdAsync(PlayerId playerId)
        {
            return await _context.PlayerScores
                .Where(ps => ps.PlayerId == playerId)
                .ToListAsync();
        }

        public async Task AddAsync(PlayerScore entity)
        {
            await _context.PlayerScores.AddAsync(entity);
        }

        public void Update(PlayerScore entity)
        {
            _context.PlayerScores.Update(entity);
        }

        public void Delete(PlayerScore entity)
        {
            _context.PlayerScores.Remove(entity);
        }

        public async Task DeleteAsync((PlayerId, MusicId, Difficulty, PlayAt) id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.PlayerScores.Remove(entity);
            }
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