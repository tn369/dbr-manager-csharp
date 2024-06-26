﻿using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Charts = new ChartRepository(_context);
            Musics = new MusicRepository(_context);
            Players = new PlayerRepository(_context);
            PlayerScores = new PlayerScoreRepository(_context);
            GameVersions = new GameVersionRepository(_context);
        }

        public IChartRepository Charts { get; private set; }
        public IMusicRepository Musics { get; private set; }
        public IPlayerRepository Players { get; private set; }
        public IPlayerScoreRepository PlayerScores { get; private set; }
        public IGameVersionRepository GameVersions { get; private set; }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}