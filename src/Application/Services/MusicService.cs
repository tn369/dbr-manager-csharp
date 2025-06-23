using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services;

public class MusicService : IMusicService
{
    private readonly IMusicRepository _musicRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MusicService(IMusicRepository musicRepository, IUnitOfWork unitOfWork)
    {
        _musicRepository = musicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Music?> GetMusicByIdAsync(MusicId musicId)
    {
        return await _musicRepository.GetByIdAsync(musicId);
    }

    public async Task<IEnumerable<Music>> GetAllMusicAsync()
    {
        return await _musicRepository.GetAllAsync();
    }

    public async Task<Music> CreateMusicAsync(MusicTitle title, Artist artist, Genre genre, Bpm bpm)
    {
        var music = new Music(title, artist, genre, bpm);
        await _musicRepository.AddAsync(music);
        await _unitOfWork.SaveChangesAsync();
        return music;
    }

    public async Task<Music> UpdateMusicAsync(Music music)
    {
        _musicRepository.Update(music);
        await _unitOfWork.SaveChangesAsync();
        return music;
    }

    public async Task DeleteMusicAsync(MusicId musicId)
    {
        var music = await _musicRepository.GetByIdAsync(musicId);
        if (music != null)
        {
            _musicRepository.Delete(music);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}