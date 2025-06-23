using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;

namespace ApplicationTest.Services;

public class MusicServiceTests
{
    private readonly Mock<IMusicRepository> _musicRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly MusicService _musicService;

    public MusicServiceTests()
    {
        _musicRepositoryMock = new Mock<IMusicRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _musicService = new MusicService(_musicRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task GetMusicByIdAsync_ShouldReturnMusic_WhenMusicExists()
    {
        var musicId = new MusicId(1);
        var expectedMusic = new Music(
            new MusicTitle("Test Song"), 
            new Artist("Test Artist"), 
            new Genre("Test Genre"), 
            new Bpm(140));
        
        _musicRepositoryMock.Setup(x => x.GetByIdAsync(musicId))
            .ReturnsAsync(expectedMusic);

        var result = await _musicService.GetMusicByIdAsync(musicId);

        result.Should().NotBeNull();
        result.Should().Be(expectedMusic);
    }

    [Fact]
    public async Task GetMusicByIdAsync_ShouldReturnNull_WhenMusicDoesNotExist()
    {
        var musicId = new MusicId(999);
        
        _musicRepositoryMock.Setup(x => x.GetByIdAsync(musicId))
            .ReturnsAsync((Music?)null);

        var result = await _musicService.GetMusicByIdAsync(musicId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAllMusicAsync_ShouldReturnAllMusic()
    {
        var musicList = new List<Music>
        {
            new Music(new MusicTitle("Song1"), new Artist("Artist1"), new Genre("Genre1"), new Bpm(120)),
            new Music(new MusicTitle("Song2"), new Artist("Artist2"), new Genre("Genre2"), new Bpm(140))
        };
        
        _musicRepositoryMock.Setup(x => x.GetAllAsync())
            .ReturnsAsync(musicList);

        var result = await _musicService.GetAllMusicAsync();

        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(musicList);
    }

    [Fact]
    public async Task CreateMusicAsync_ShouldCreateAndReturnMusic()
    {
        var title = new MusicTitle("New Song");
        var artist = new Artist("New Artist");
        var genre = new Genre("New Genre");
        var bpm = new Bpm(160);

        _musicRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Music>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        var result = await _musicService.CreateMusicAsync(title, artist, genre, bpm);

        result.Should().NotBeNull();
        result.Title.Should().Be(title);
        result.Artist.Should().Be(artist);
        result.Genre.Should().Be(genre);
        result.Bpm.Should().Be(bpm);
        
        _musicRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Music>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateMusicAsync_ShouldUpdateMusic()
    {
        var music = new Music(
            new MusicTitle("Test Song"), 
            new Artist("Test Artist"), 
            new Genre("Test Genre"), 
            new Bpm(140));

        _musicRepositoryMock.Setup(x => x.Update(music));
        _unitOfWorkMock.Setup(x => x.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        var result = await _musicService.UpdateMusicAsync(music);

        result.Should().Be(music);
        _musicRepositoryMock.Verify(x => x.Update(music), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteMusicAsync_ShouldDeleteMusic_WhenMusicExists()
    {
        var musicId = new MusicId(1);
        var music = new Music(
            new MusicTitle("Test Song"), 
            new Artist("Test Artist"), 
            new Genre("Test Genre"), 
            new Bpm(140));

        _musicRepositoryMock.Setup(x => x.GetByIdAsync(musicId))
            .ReturnsAsync(music);
        _musicRepositoryMock.Setup(x => x.Delete(music));
        _unitOfWorkMock.Setup(x => x.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        await _musicService.DeleteMusicAsync(musicId);

        _musicRepositoryMock.Verify(x => x.GetByIdAsync(musicId), Times.Once);
        _musicRepositoryMock.Verify(x => x.Delete(music), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteMusicAsync_ShouldNotDelete_WhenMusicDoesNotExist()
    {
        var musicId = new MusicId(999);

        _musicRepositoryMock.Setup(x => x.GetByIdAsync(musicId))
            .ReturnsAsync((Music?)null);

        await _musicService.DeleteMusicAsync(musicId);

        _musicRepositoryMock.Verify(x => x.GetByIdAsync(musicId), Times.Once);
        _musicRepositoryMock.Verify(x => x.Delete(It.IsAny<Music>()), Times.Never);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Never);
    }
}