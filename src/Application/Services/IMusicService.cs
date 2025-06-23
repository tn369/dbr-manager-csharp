using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services;

public interface IMusicService
{
    Task<Music?> GetMusicByIdAsync(MusicId musicId);
    Task<IEnumerable<Music>> GetAllMusicAsync();
    Task<Music> CreateMusicAsync(MusicTitle title, Artist artist, Genre genre, Bpm bpm);
    Task<Music> UpdateMusicAsync(Music music);
    Task DeleteMusicAsync(MusicId musicId);
}