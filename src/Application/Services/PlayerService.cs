using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlayerService(IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
    {
        _playerRepository = playerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Player?> GetPlayerByIdAsync(PlayerId playerId)
    {
        return await _playerRepository.GetByIdAsync(playerId);
    }

    public async Task<IEnumerable<Player>> GetAllPlayersAsync()
    {
        return await _playerRepository.GetAllAsync();
    }

    public async Task<Player> CreatePlayerAsync(DJName djName, Profile profile)
    {
        var player = new Player(djName, profile);
        await _playerRepository.AddAsync(player);
        await _unitOfWork.SaveChangesAsync();
        return player;
    }

    public async Task<Player> UpdatePlayerAsync(Player player)
    {
        _playerRepository.Update(player);
        await _unitOfWork.SaveChangesAsync();
        return player;
    }

    public async Task DeletePlayerAsync(PlayerId playerId)
    {
        var player = await _playerRepository.GetByIdAsync(playerId);
        if (player != null)
        {
            _playerRepository.Delete(player);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}