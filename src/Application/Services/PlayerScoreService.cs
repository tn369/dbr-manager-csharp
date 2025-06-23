using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services;

public class PlayerScoreService : IPlayerScoreService
{
    private readonly IPlayerScoreRepository _playerScoreRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IChartRepository _chartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlayerScoreService(
        IPlayerScoreRepository playerScoreRepository,
        IPlayerRepository playerRepository,
        IChartRepository chartRepository,
        IUnitOfWork unitOfWork)
    {
        _playerScoreRepository = playerScoreRepository;
        _playerRepository = playerRepository;
        _chartRepository = chartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PlayerScore?> GetPlayerScoreByIdAsync(PlayerId playerId, int chartId)
    {
        return await _playerScoreRepository.GetByPlayerAndChartAsync(playerId, chartId);
    }

    public async Task<IEnumerable<PlayerScore>> GetPlayerScoresByPlayerIdAsync(PlayerId playerId)
    {
        return await _playerScoreRepository.GetByPlayerIdAsync(playerId);
    }

    public async Task<PlayerScore> CreatePlayerScoreAsync(PlayerId playerId, int chartId, Score score, EXScore exScore, Judge judge, ClearLamp clearLamp, PlayAt playAt)
    {
        var player = await _playerRepository.GetByIdAsync(playerId);
        if (player == null)
            throw new ArgumentException("Player not found", nameof(playerId));

        var chart = await _chartRepository.GetByIdAsync(chartId);
        if (chart == null)
            throw new ArgumentException("Chart not found", nameof(chartId));

        var playerScore = new PlayerScore(playerId, chart.GameMode, chart.MusicId, chart.Difficulty, null, playAt, score, clearLamp, null);
        await _playerScoreRepository.AddAsync(playerScore);
        await _unitOfWork.SaveChangesAsync();
        return playerScore;
    }

    public async Task<PlayerScore> UpdatePlayerScoreAsync(PlayerScore playerScore)
    {
        _playerScoreRepository.Update(playerScore);
        await _unitOfWork.SaveChangesAsync();
        return playerScore;
    }

    public async Task DeletePlayerScoreAsync(PlayerId playerId, int chartId)
    {
        var playerScore = await _playerScoreRepository.GetByPlayerAndChartAsync(playerId, chartId);
        if (playerScore != null)
        {
            _playerScoreRepository.Delete(playerScore);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}