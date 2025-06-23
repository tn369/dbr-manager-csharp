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
            PlayerId = s.Player.Id.Value,
            ChartId = s.Chart.Id,
            Score = s.Score.Value,
            EXScore = s.EXScore.Value,
            Judge = new
            {
                PGreat = s.Judge.PGreat,
                Great = s.Judge.Great,
                Good = s.Judge.Good,
                Bad = s.Judge.Bad,
                Poor = s.Judge.Poor
            },
            ClearLamp = s.ClearLamp.Value,
            PlayAt = s.PlayAt.Value,
            Memo = s.Memo?.Value
        }));
    }

    [HttpGet("player/{playerId}/chart/{chartId}")]
    public async Task<IActionResult> GetPlayerScore(string playerId, int chartId)
    {
        var playerIdValue = new PlayerId(playerId);
        var score = await _playerScoreService.GetPlayerScoreByIdAsync(playerIdValue, chartId);
        
        if (score == null)
            return NotFound();

        return Ok(new
        {
            PlayerId = score.Player.Id.Value,
            ChartId = score.Chart.Id,
            Score = score.Score.Value,
            EXScore = score.EXScore.Value,
            Judge = new
            {
                PGreat = score.Judge.PGreat,
                Great = score.Judge.Great,
                Good = score.Judge.Good,
                Bad = score.Judge.Bad,
                Poor = score.Judge.Poor
            },
            ClearLamp = score.ClearLamp.Value,
            PlayAt = score.PlayAt.Value,
            Memo = score.Memo?.Value
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayerScore([FromBody] CreatePlayerScoreRequest request)
    {
        var playerId = new PlayerId(request.PlayerId);
        var score = new Score(request.Score);
        var exScore = new EXScore(request.EXScore);
        var judge = new Judge(request.Judge.PGreat, request.Judge.Great, request.Judge.Good, request.Judge.Bad, request.Judge.Poor);
        var clearLamp = new ClearLamp(request.ClearLamp);
        var playAt = new PlayAt(request.PlayAt);
        
        var playerScore = await _playerScoreService.CreatePlayerScoreAsync(
            playerId, request.ChartId, score, exScore, judge, clearLamp, playAt);
        
        return CreatedAtAction(nameof(GetPlayerScore), 
            new { playerId = request.PlayerId, chartId = request.ChartId }, 
            new
            {
                PlayerId = playerScore.Player.Id.Value,
                ChartId = playerScore.Chart.Id,
                Score = playerScore.Score.Value,
                EXScore = playerScore.EXScore.Value,
                Judge = new
                {
                    PGreat = playerScore.Judge.PGreat,
                    Great = playerScore.Judge.Great,
                    Good = playerScore.Judge.Good,
                    Bad = playerScore.Judge.Bad,
                    Poor = playerScore.Judge.Poor
                },
                ClearLamp = playerScore.ClearLamp.Value,
                PlayAt = playerScore.PlayAt.Value
            });
    }

    [HttpDelete("player/{playerId}/chart/{chartId}")]
    public async Task<IActionResult> DeletePlayerScore(string playerId, int chartId)
    {
        var playerIdValue = new PlayerId(playerId);
        await _playerScoreService.DeletePlayerScoreAsync(playerIdValue, chartId);
        return NoContent();
    }
}

public record CreatePlayerScoreRequest(
    string PlayerId,
    int ChartId,
    int Score,
    int EXScore,
    JudgeRequest Judge,
    int ClearLamp,
    DateTime PlayAt);

public record JudgeRequest(int PGreat, int Great, int Good, int Bad, int Poor);