using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IMusicRepository : IRepository<Music, MusicId> { }
}
