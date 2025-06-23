using API.Controllers;
using Application.Services;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace APITest.Controllers;

public class MusicControllerTests
{
    private readonly Mock<IMusicService> _musicServiceMock;
    private readonly MusicController _controller;

    public MusicControllerTests()
    {
        _musicServiceMock = new Mock<IMusicService>();
        _controller = new MusicController(_musicServiceMock.Object);
    }

    [Fact]
    public async Task GetAllMusic_ShouldReturnOkWithMusic()
    {
        var musicList = new List<Music>
        {
            new Music(new MusicTitle("Song1"), new Artist("Artist1"), new Genre("Genre1"), new Bpm(120)),
            new Music(new MusicTitle("Song2"), new Artist("Artist2"), new Genre("Genre2"), new Bpm(140))
        };

        _musicServiceMock.Setup(x => x.GetAllMusicAsync())
            .ReturnsAsync(musicList);

        var result = await _controller.GetAllMusic();

        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMusic_ShouldReturnOkWithMusic_WhenMusicExists()
    {
        var musicId = 1;
        var music = new Music(
            new MusicTitle("Test Song"), 
            new Artist("Test Artist"), 
            new Genre("Test Genre"), 
            new Bpm(140));

        _musicServiceMock.Setup(x => x.GetMusicByIdAsync(It.Is<MusicId>(m => m.Value == musicId)))
            .ReturnsAsync(music);

        var result = await _controller.GetMusic(musicId);

        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMusic_ShouldReturnNotFound_WhenMusicDoesNotExist()
    {
        var musicId = 999;

        _musicServiceMock.Setup(x => x.GetMusicByIdAsync(It.Is<MusicId>(m => m.Value == musicId)))
            .ReturnsAsync((Music?)null);

        var result = await _controller.GetMusic(musicId);

        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task CreateMusic_ShouldReturnCreatedAtAction()
    {
        var request = new CreateMusicRequest("New Song", "New Artist", "New Genre", 160);
        var createdMusic = new Music(
            new MusicTitle(request.Title),
            new Artist(request.Artist),
            new Genre(request.Genre),
            new Bpm(request.Bpm));

        _musicServiceMock.Setup(x => x.CreateMusicAsync(
                It.Is<MusicTitle>(t => t.Value == request.Title),
                It.Is<Artist>(a => a.Value == request.Artist),
                It.Is<Genre>(g => g.Value == request.Genre),
                It.Is<Bpm>(b => b.Value == request.Bpm)))
            .ReturnsAsync(createdMusic);

        var result = await _controller.CreateMusic(request);

        result.Should().BeOfType<CreatedAtActionResult>();
        var createdResult = result as CreatedAtActionResult;
        createdResult!.ActionName.Should().Be(nameof(MusicController.GetMusic));
        createdResult.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateMusic_ShouldReturnOk_WhenMusicExists()
    {
        var musicId = 1;
        var request = new UpdateMusicRequest("Updated Title", "Updated Artist", "Updated Genre", 180);
        var existingMusic = new Music(
            new MusicTitle("Old Title"),
            new Artist("Old Artist"),
            new Genre("Old Genre"),
            new Bpm(120));

        _musicServiceMock.Setup(x => x.GetMusicByIdAsync(It.Is<MusicId>(m => m.Value == musicId)))
            .ReturnsAsync(existingMusic);
        _musicServiceMock.Setup(x => x.UpdateMusicAsync(existingMusic))
            .ReturnsAsync(existingMusic);

        var result = await _controller.UpdateMusic(musicId, request);

        result.Should().BeOfType<OkObjectResult>();
        _musicServiceMock.Verify(x => x.UpdateMusicAsync(existingMusic), Times.Once);
    }

    [Fact]
    public async Task UpdateMusic_ShouldReturnNotFound_WhenMusicDoesNotExist()
    {
        var musicId = 999;
        var request = new UpdateMusicRequest("Updated Title", "Updated Artist", "Updated Genre", 180);

        _musicServiceMock.Setup(x => x.GetMusicByIdAsync(It.Is<MusicId>(m => m.Value == musicId)))
            .ReturnsAsync((Music?)null);

        var result = await _controller.UpdateMusic(musicId, request);

        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task DeleteMusic_ShouldReturnNoContent()
    {
        var musicId = 1;

        _musicServiceMock.Setup(x => x.DeleteMusicAsync(It.Is<MusicId>(m => m.Value == musicId)))
            .Returns(Task.CompletedTask);

        var result = await _controller.DeleteMusic(musicId);

        result.Should().BeOfType<NoContentResult>();
        _musicServiceMock.Verify(x => x.DeleteMusicAsync(It.Is<MusicId>(m => m.Value == musicId)), Times.Once);
    }
}