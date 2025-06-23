using Application.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerScoresController : ControllerBase
{
    private readonly IPlayerScoreService _playerScoreService;

    public PlayerScoresController(IPlayerScoreService playerScoreService)
    {
        _playerScoreService = playerScoreService;
    }

    [HttpGet("player/{playerId}")]
    public async Task<IActionResult> GetPlayerScores(string playerId)
    {
        var playerIdValue = new PlayerId(playerId);
        var scores = await _playerScoreService.GetPlayerScoresByPlayerIdAsync(playerIdValue);
        
        return Ok(scores.Select(s => new
        {
            PlayerId = s.PlayerId.Value,
            MusicId = s.MusicId.Value,
            Difficulty = s.Difficulty.Value,
            PlayAt = s.PlayAt.Value,
            Memo = s.Memo?.Value
        }));
    }

    [HttpDelete("player/{playerId}/chart/{chartId}")]
    public async Task<IActionResult> DeletePlayerScore(string playerId, int chartId)
    {
        var playerIdValue = new PlayerId(playerId);
        await _playerScoreService.DeletePlayerScoreAsync(playerIdValue, chartId);
        return NoContent();
    }
}