using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class PlayerScore
    {
        public PlayerId PlayerId { get; private set; }
        public MusicId MusicId { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public PlayAt PlayAt { get; private set; }
        public PlaySettings PlaySettings { get; private set; }
        public Score Score { get; private set; }
        public ClearLamp ClearLamp { get; private set; }
        public Memo Memo { get; private set; }

        public PlayerScore(PlayerId playerId, MusicId musicId, Difficulty difficulty, PlayAt playAt, PlaySettings playSettings, Score score, ClearLamp clearLamp, Memo memo)
        {
            PlayerId = playerId ?? throw new ArgumentNullException(nameof(playerId));
            MusicId = musicId ?? throw new ArgumentNullException(nameof(musicId));
            Difficulty = difficulty ?? throw new ArgumentNullException(nameof(difficulty));
            PlayAt = playAt ?? throw new ArgumentNullException(nameof(playAt));
            PlaySettings = playSettings ?? throw new ArgumentNullException(nameof(playSettings));
            Score = score ?? throw new ArgumentNullException(nameof(score));
            ClearLamp = clearLamp ?? throw new ArgumentNullException(nameof(clearLamp));
            Memo = memo ?? throw new ArgumentNullException(nameof(memo));
        }
        private PlayerScore() { }
    }
}
