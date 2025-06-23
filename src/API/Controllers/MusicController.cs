using Application.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase
{
    private readonly IMusicService _musicService;

    public MusicController(IMusicService musicService)
    {
        _musicService = musicService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMusic()
    {
        var music = await _musicService.GetAllMusicAsync();
        return Ok(music.Select(m => new
        {
            Id = m.Id.Value,
            Title = m.Title.Value,
            Artist = m.Artist.Value,
            Genre = m.Genre.Value,
            Bpm = m.Bpm.Value
        }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMusic(int id)
    {
        var musicId = new MusicId(id);
        var music = await _musicService.GetMusicByIdAsync(musicId);
        
        if (music == null)
            return NotFound();

        return Ok(new
        {
            Id = music.Id.Value,
            Title = music.Title.Value,
            Artist = music.Artist.Value,
            Genre = music.Genre.Value,
            Bpm = music.Bpm.Value
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateMusic([FromBody] CreateMusicRequest request)
    {
        var title = new MusicTitle(request.Title);
        var artist = new Artist(request.Artist);
        var genre = new Genre(request.Genre);
        var bpm = new Bpm(request.Bpm);
        
        var music = await _musicService.CreateMusicAsync(title, artist, genre, bpm);
        
        return CreatedAtAction(nameof(GetMusic), new { id = music.Id.Value }, new
        {
            Id = music.Id.Value,
            Title = music.Title.Value,
            Artist = music.Artist.Value,
            Genre = music.Genre.Value,
            Bpm = music.Bpm.Value
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMusic(int id, [FromBody] UpdateMusicRequest request)
    {
        var musicId = new MusicId(id);
        var music = await _musicService.GetMusicByIdAsync(musicId);
        
        if (music == null)
            return NotFound();

        if (!string.IsNullOrEmpty(request.Title))
            music.ChangeTitle(new MusicTitle(request.Title));
        
        if (!string.IsNullOrEmpty(request.Artist))
            music.ChangeArtist(new Artist(request.Artist));
        
        if (!string.IsNullOrEmpty(request.Genre))
            music.ChangeGenre(new Genre(request.Genre));
        
        if (request.Bpm.HasValue)
            music.ChangeBpm(new Bpm(request.Bpm.Value));

        await _musicService.UpdateMusicAsync(music);
        
        return Ok(new
        {
            Id = music.Id.Value,
            Title = music.Title.Value,
            Artist = music.Artist.Value,
            Genre = music.Genre.Value,
            Bpm = music.Bpm.Value
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMusic(int id)
    {
        var musicId = new MusicId(id);
        await _musicService.DeleteMusicAsync(musicId);
        return NoContent();
    }
}

public record CreateMusicRequest(string Title, string Artist, string Genre, int Bpm);
public record UpdateMusicRequest(string? Title, string? Artist, string? Genre, int? Bpm);