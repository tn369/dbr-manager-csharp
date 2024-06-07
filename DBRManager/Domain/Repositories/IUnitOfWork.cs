namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IChartRepository Charts { get; }
        IClearLampRepository ClearLamps { get; }
        IDifficultyRepository Difficulties { get; }
        IMusicRepository Musics { get; }
        IOptionRepository Options { get; }
        IPlayerRepository Players { get; }
        IPlayerScoreRepository PlayerScores { get; }
        IRivalRepository Rivals { get; }
        IVersionRepository Versions { get; }

        Task<int> CompleteAsync();
    }
}
