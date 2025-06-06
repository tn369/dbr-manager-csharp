﻿using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IPlayerScoreRepository : IRepository<PlayerScore, (PlayerId, MusicId, Difficulty, PlayAt)>
    {
        Task<IEnumerable<PlayerScore>> GetScoresByPlayerIdAsync(PlayerId playerId);
        Task<IEnumerable<PlayerScore>> GetScoresByMusicIdAsync(MusicId musicId);
    }
}
