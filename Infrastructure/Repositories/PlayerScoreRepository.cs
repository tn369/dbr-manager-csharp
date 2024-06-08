using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class PlayerScoreRepository : Repository<PlayerScore, (PlayerId, MusicId, DifficultyId)>, IPlayerScoreRepository
    {
        public PlayerScoreRepository(ApplicationDbContext context) : base(context) { }
    }
}