using API.Controllers;
using Application.Services;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace APITest.Controllers;

public class PlayersControllerTests
{
    private readonly Mock<IPlayerService> _playerServiceMock;
    private readonly PlayersController _controller;

    public PlayersControllerTests()
    {
        _playerServiceMock = new Mock<IPlayerService>();
        _controller = new PlayersController(_playerServiceMock.Object);
    }

    [Fact]
    public async Task GetAllPlayers_ShouldReturnOkWithPlayers()
    {
        var players = new List<Player>
        {
            new Player(new DJName("Player1"), new Profile("Profile1")),
            new Player(new DJName("Player2"), new Profile("Profile2"))
        };

        _playerServiceMock.Setup(x => x.GetAllPlayersAsync())
            .ReturnsAsync(players);

        var result = await _controller.GetAllPlayers();

        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPlayer_ShouldReturnOkWithPlayer_WhenPlayerExists()
    {
        var playerId = "test-player-id";
        var player = new Player(new DJName("TestPlayer"), new Profile("Test Profile"));

        _playerServiceMock.Setup(x => x.GetPlayerByIdAsync(It.Is<PlayerId>(p => p.Value == playerId)))
            .ReturnsAsync(player);

        var result = await _controller.GetPlayer(playerId);

        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPlayer_ShouldReturnNotFound_WhenPlayerDoesNotExist()
    {
        var playerId = "non-existent-id";

        _playerServiceMock.Setup(x => x.GetPlayerByIdAsync(It.Is<PlayerId>(p => p.Value == playerId)))
            .ReturnsAsync((Player?)null);

        var result = await _controller.GetPlayer(playerId);

        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task CreatePlayer_ShouldReturnCreatedAtAction()
    {
        var request = new CreatePlayerRequest("NewPlayer", "New Profile");
        var createdPlayer = new Player(new DJName(request.DJName), new Profile(request.Profile));

        _playerServiceMock.Setup(x => x.CreatePlayerAsync(
                It.Is<DJName>(d => d.Value == request.DJName),
                It.Is<Profile>(p => p.Value == request.Profile)))
            .ReturnsAsync(createdPlayer);

        var result = await _controller.CreatePlayer(request);

        result.Should().BeOfType<CreatedAtActionResult>();
        var createdResult = result as CreatedAtActionResult;
        createdResult!.ActionName.Should().Be(nameof(PlayersController.GetPlayer));
        createdResult.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdatePlayer_ShouldReturnOk_WhenPlayerExists()
    {
        var playerId = "test-player-id";
        var request = new UpdatePlayerRequest("UpdatedName", "Updated Profile");
        var existingPlayer = new Player(new DJName("OldName"), new Profile("Old Profile"));

        _playerServiceMock.Setup(x => x.GetPlayerByIdAsync(It.Is<PlayerId>(p => p.Value == playerId)))
            .ReturnsAsync(existingPlayer);
        _playerServiceMock.Setup(x => x.UpdatePlayerAsync(existingPlayer))
            .ReturnsAsync(existingPlayer);

        var result = await _controller.UpdatePlayer(playerId, request);

        result.Should().BeOfType<OkObjectResult>();
        _playerServiceMock.Verify(x => x.UpdatePlayerAsync(existingPlayer), Times.Once);
    }

    [Fact]
    public async Task UpdatePlayer_ShouldReturnNotFound_WhenPlayerDoesNotExist()
    {
        var playerId = "non-existent-id";
        var request = new UpdatePlayerRequest("UpdatedName", "Updated Profile");

        _playerServiceMock.Setup(x => x.GetPlayerByIdAsync(It.Is<PlayerId>(p => p.Value == playerId)))
            .ReturnsAsync((Player?)null);

        var result = await _controller.UpdatePlayer(playerId, request);

        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task DeletePlayer_ShouldReturnNoContent()
    {
        var playerId = "test-player-id";

        _playerServiceMock.Setup(x => x.DeletePlayerAsync(It.Is<PlayerId>(p => p.Value == playerId)))
            .Returns(Task.CompletedTask);

        var result = await _controller.DeletePlayer(playerId);

        result.Should().BeOfType<NoContentResult>();
        _playerServiceMock.Verify(x => x.DeletePlayerAsync(It.Is<PlayerId>(p => p.Value == playerId)), Times.Once);
    }
}