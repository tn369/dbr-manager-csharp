namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IChartRepository Charts { get; }
        IDifficultyRepository Difficulties { get; }
        IMusicRepository Musics { get; }
        IPlayerRepository Players { get; }
        IPlayerScoreRepository PlayerScores { get; }
        IRivalRepository Rivals { get; }
        IVersionRepository Versions { get; }

        Task<int> CompleteAsync();
    }
}
