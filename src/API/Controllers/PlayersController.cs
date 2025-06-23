using Application.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var players = await _playerService.GetAllPlayersAsync();
        return Ok(players.Select(p => new
        {
            Id = p.Id.Value,
            DJName = p.DJName.Value,
            Profile = p.Profile.Value
        }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayer(string id)
    {
        var playerId = new PlayerId(id);
        var player = await _playerService.GetPlayerByIdAsync(playerId);
        
        if (player == null)
            return NotFound();

        return Ok(new
        {
            Id = player.Id.Value,
            DJName = player.DJName.Value,
            Profile = player.Profile.Value
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequest request)
    {
        var djName = new DJName(request.DJName);
        var profile = new Profile(request.Profile);
        
        var player = await _playerService.CreatePlayerAsync(djName, profile);
        
        return CreatedAtAction(nameof(GetPlayer), new { id = player.Id.Value }, new
        {
            Id = player.Id.Value,
            DJName = player.DJName.Value,
            Profile = player.Profile.Value
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayer(string id, [FromBody] UpdatePlayerRequest request)
    {
        var playerId = new PlayerId(id);
        var player = await _playerService.GetPlayerByIdAsync(playerId);
        
        if (player == null)
            return NotFound();

        if (!string.IsNullOrEmpty(request.DJName))
            player.ChangeDJName(new DJName(request.DJName));
        
        if (!string.IsNullOrEmpty(request.Profile))
            player.ChangeProfile(new Profile(request.Profile));

        await _playerService.UpdatePlayerAsync(player);
        
        return Ok(new
        {
            Id = player.Id.Value,
            DJName = player.DJName.Value,
            Profile = player.Profile.Value
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(string id)
    {
        var playerId = new PlayerId(id);
        await _playerService.DeletePlayerAsync(playerId);
        return NoContent();
    }
}

public record CreatePlayerRequest(string DJName, string Profile);
public record UpdatePlayerRequest(string? DJName, string? Profile);