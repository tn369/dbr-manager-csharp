using API.Controllers;
using Application.Services;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace APITest.Controllers;

public class PlayerScoresControllerTests
{
    private readonly Mock<IPlayerScoreService> _playerScoreServiceMock;
    private readonly PlayerScoresController _controller;

    public PlayerScoresControllerTests()
    {
        _playerScoreServiceMock = new Mock<IPlayerScoreService>();
        _controller = new PlayerScoresController(_playerScoreServiceMock.Object);
    }

    [Fact]
    public async Task GetPlayerScores_ShouldReturnOkWithScores()
    {
        var playerId = "test-player-id";
        var scores = new List<PlayerScore>
        {
            CreateTestPlayerScore(),
            CreateTestPlayerScore()
        };

        _playerScoreServiceMock.Setup(x => x.GetPlayerScoresByPlayerIdAsync(It.Is<PlayerId>(p => p.Value == playerId)))
            .ReturnsAsync(scores);

        var result = await _controller.GetPlayerScores(playerId);

        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task DeletePlayerScore_ShouldReturnNoContent()
    {
        var playerId = "test-player-id";
        var chartId = 1;

        _playerScoreServiceMock.Setup(x => x.DeletePlayerScoreAsync(
                It.Is<PlayerId>(p => p.Value == playerId), chartId))
            .Returns(Task.CompletedTask);

        var result = await _controller.DeletePlayerScore(playerId, chartId);

        result.Should().BeOfType<NoContentResult>();
        _playerScoreServiceMock.Verify(x => x.DeletePlayerScoreAsync(
            It.Is<PlayerId>(p => p.Value == playerId), chartId), Times.Once);
    }

    private static PlayerScore CreateTestPlayerScore()
    {
        var playerId = new PlayerId("test-player-id");
        var gameMode = new GameMode(Domain.Enums.GameModeType.Single);
        var musicId = new MusicId(1);
        var difficulty = new Difficulty(Domain.Enums.DifficultyType.Normal);
        var playAt = new PlayAt(DateTime.Now);
        var judge = new Judge(100);
        var exScore = new EXScore(judge, judge);
        var score = new Score(exScore, judge, judge);
        var clearLamp = new ClearLamp(Domain.Enums.ClearLampType.Clear);
        var memo = new Memo("");

        return new PlayerScore(playerId, gameMode, musicId, difficulty, null, playAt, score, clearLamp, memo);
    }
}