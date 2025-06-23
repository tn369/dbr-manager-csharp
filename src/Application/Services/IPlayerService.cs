using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services;

public interface IPlayerService
{
    Task<Player?> GetPlayerByIdAsync(PlayerId playerId);
    Task<IEnumerable<Player>> GetAllPlayersAsync();
    Task<Player> CreatePlayerAsync(DJName djName, Profile profile);
    Task<Player> UpdatePlayerAsync(Player player);
    Task DeletePlayerAsync(PlayerId playerId);
}