using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;
using Xunit;

namespace ApplicationTest.Services;

public class PlayerServiceTests
{
    private readonly Mock<IPlayerRepository> _playerRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly PlayerService _playerService;

    public PlayerServiceTests()
    {
        _playerRepositoryMock = new Mock<IPlayerRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _playerService = new PlayerService(_playerRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task GetPlayerByIdAsync_ShouldReturnPlayer_WhenPlayerExists()
    {
        var playerId = new PlayerId("test-player-id");
        var expectedPlayer = new Player(new DJName("TestDJ"), new Profile("Test Profile"));
        
        _playerRepositoryMock.Setup(x => x.GetByIdAsync(playerId))
            .ReturnsAsync(expectedPlayer);

        var result = await _playerService.GetPlayerByIdAsync(playerId);

        result.Should().NotBeNull();
        result.Should().Be(expectedPlayer);
    }

    [Fact]
    public async Task GetPlayerByIdAsync_ShouldReturnNull_WhenPlayerDoesNotExist()
    {
        var playerId = new PlayerId("non-existent-id");
        
        _playerRepositoryMock.Setup(x => x.GetByIdAsync(playerId))
            .ReturnsAsync((Player?)null);

        var result = await _playerService.GetPlayerByIdAsync(playerId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAllPlayersAsync_ShouldReturnAllPlayers()
    {
        var players = new List<Player>
        {
            new Player(new DJName("Player1"), new Profile("Profile1")),
            new Player(new DJName("Player2"), new Profile("Profile2"))
        };
        
        _playerRepositoryMock.Setup(x => x.GetAllAsync())
            .ReturnsAsync(players);

        var result = await _playerService.GetAllPlayersAsync();

        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(players);
    }

    [Fact]
    public async Task CreatePlayerAsync_ShouldCreateAndReturnPlayer()
    {
        var djName = new DJName("NewPlayer");
        var profile = new Profile("New Profile");

        _playerRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Player>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        var result = await _playerService.CreatePlayerAsync(djName, profile);

        result.Should().NotBeNull();
        result.DJName.Should().Be(djName);
        result.Profile.Should().Be(profile);
        
        _playerRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Player>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdatePlayerAsync_ShouldUpdatePlayer()
    {
        var player = new Player(new DJName("TestPlayer"), new Profile("Test Profile"));

        _playerRepositoryMock.Setup(x => x.Update(player));
        _unitOfWorkMock.Setup(x => x.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        var result = await _playerService.UpdatePlayerAsync(player);

        result.Should().Be(player);
        _playerRepositoryMock.Verify(x => x.Update(player), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeletePlayerAsync_ShouldDeletePlayer_WhenPlayerExists()
    {
        var playerId = new PlayerId("test-player-id");
        var player = new Player(new DJName("TestPlayer"), new Profile("Test Profile"));

        _playerRepositoryMock.Setup(x => x.GetByIdAsync(playerId))
            .ReturnsAsync(player);
        _playerRepositoryMock.Setup(x => x.Delete(player));
        _unitOfWorkMock.Setup(x => x.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        await _playerService.DeletePlayerAsync(playerId);

        _playerRepositoryMock.Verify(x => x.GetByIdAsync(playerId), Times.Once);
        _playerRepositoryMock.Verify(x => x.Delete(player), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeletePlayerAsync_ShouldNotDelete_WhenPlayerDoesNotExist()
    {
        var playerId = new PlayerId("non-existent-id");

        _playerRepositoryMock.Setup(x => x.GetByIdAsync(playerId))
            .ReturnsAsync((Player?)null);

        await _playerService.DeletePlayerAsync(playerId);

        _playerRepositoryMock.Verify(x => x.GetByIdAsync(playerId), Times.Once);
        _playerRepositoryMock.Verify(x => x.Delete(It.IsAny<Player>()), Times.Never);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Never);
    }
}