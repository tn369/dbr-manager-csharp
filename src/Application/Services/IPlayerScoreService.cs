using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services;

public interface IPlayerScoreService
{
    Task<PlayerScore?> GetPlayerScoreByIdAsync(PlayerId playerId, int chartId);
    Task<IEnumerable<PlayerScore>> GetPlayerScoresByPlayerIdAsync(PlayerId playerId);
    Task<PlayerScore> CreatePlayerScoreAsync(PlayerId playerId, int chartId, Score score, EXScore exScore, Judge judge, ClearLamp clearLamp, PlayAt playAt);
    Task<PlayerScore> UpdatePlayerScoreAsync(PlayerScore playerScore);
    Task DeletePlayerScoreAsync(PlayerId playerId, int chartId);
}