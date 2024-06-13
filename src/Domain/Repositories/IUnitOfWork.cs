namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IChartRepository Charts { get; }
        IMusicRepository Musics { get; }
        IPlayerRepository Players { get; }
        IPlayerScoreRepository PlayerScores { get; }
        IGameVersionRepository GameVersions { get; }

        Task<int> CompleteAsync();
    }
}
