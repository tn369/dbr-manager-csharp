using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;
using Xunit;

namespace ApplicationTest.Services;

public class PlayerScoreServiceTests
{
    private readonly Mock<IPlayerScoreRepository> _playerScoreRepositoryMock;
    private readonly Mock<IPlayerRepository> _playerRepositoryMock;
    private readonly Mock<IChartRepository> _chartRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly PlayerScoreService _playerScoreService;

    public PlayerScoreServiceTests()
    {
        _playerScoreRepositoryMock = new Mock<IPlayerScoreRepository>();
        _playerRepositoryMock = new Mock<IPlayerRepository>();
        _chartRepositoryMock = new Mock<IChartRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _playerScoreService = new PlayerScoreService(
            _playerScoreRepositoryMock.Object,
            _playerRepositoryMock.Object,
            _chartRepositoryMock.Object,
            _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task GetPlayerScoreByIdAsync_ShouldReturnPlayerScore_WhenScoreExists()
    {
        var playerId = new PlayerId("test-player-id");
        var chartId = 1;
        var expectedScore = CreateTestPlayerScore();
        
        _playerScoreRepositoryMock.Setup(x => x.GetByPlayerAndChartAsync(playerId, chartId))
            .ReturnsAsync(expectedScore);

        var result = await _playerScoreService.GetPlayerScoreByIdAsync(playerId, chartId);

        result.Should().NotBeNull();
        result.Should().Be(expectedScore);
    }

    [Fact]
    public async Task GetPlayerScoreByIdAsync_ShouldReturnNull_WhenScoreDoesNotExist()
    {
        var playerId = new PlayerId("non-existent-id");
        var chartId = 999;
        
        _playerScoreRepositoryMock.Setup(x => x.GetByPlayerAndChartAsync(playerId, chartId))
            .ReturnsAsync((PlayerScore?)null);

        var result = await _playerScoreService.GetPlayerScoreByIdAsync(playerId, chartId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetPlayerScoresByPlayerIdAsync_ShouldReturnAllScoresForPlayer()
    {
        var playerId = new PlayerId("test-player-id");
        var scores = new List<PlayerScore>
        {
            CreateTestPlayerScore(),
            CreateTestPlayerScore()
        };
        
        _playerScoreRepositoryMock.Setup(x => x.GetByPlayerIdAsync(playerId))
            .ReturnsAsync(scores);

        var result = await _playerScoreService.GetPlayerScoresByPlayerIdAsync(playerId);

        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(scores);
    }

    [Fact]
    public async Task DeletePlayerScoreAsync_ShouldDeleteScore()
    {
        var playerId = new PlayerId("test-player-id");
        var chartId = 1;
        var score = CreateTestPlayerScore();

        _playerScoreRepositoryMock.Setup(x => x.GetByPlayerAndChartAsync(playerId, chartId))
            .ReturnsAsync(score);
        _playerScoreRepositoryMock.Setup(x => x.Delete(score));
        _unitOfWorkMock.Setup(x => x.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        await _playerScoreService.DeletePlayerScoreAsync(playerId, chartId);

        _playerScoreRepositoryMock.Verify(x => x.GetByPlayerAndChartAsync(playerId, chartId), Times.Once);
        _playerScoreRepositoryMock.Verify(x => x.Delete(score), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeletePlayerScoreAsync_ShouldNotDelete_WhenScoreDoesNotExist()
    {
        var playerId = new PlayerId("non-existent-id");
        var chartId = 999;

        _playerScoreRepositoryMock.Setup(x => x.GetByPlayerAndChartAsync(playerId, chartId))
            .ReturnsAsync((PlayerScore?)null);

        await _playerScoreService.DeletePlayerScoreAsync(playerId, chartId);

        _playerScoreRepositoryMock.Verify(x => x.GetByPlayerAndChartAsync(playerId, chartId), Times.Once);
        _playerScoreRepositoryMock.Verify(x => x.Delete(It.IsAny<PlayerScore>()), Times.Never);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Never);
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