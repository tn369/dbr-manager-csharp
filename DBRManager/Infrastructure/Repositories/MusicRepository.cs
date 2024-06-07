using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class MusicRepository : Repository<Music, MusicId>, IMusicRepository
    {
        public MusicRepository(ApplicationDbContext context) : base(context) { }
    }
}