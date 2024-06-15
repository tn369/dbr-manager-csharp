using Domain.ValueObjects;
using Domain.ValueObjects.Options;

namespace Domain.Entities
{
    public sealed class PlayerScore
    {
        public PlayerId PlayerId { get; private set; }
        public GameMode GameMode { get; private set; }
        public MusicId MusicId { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public PlayOptionBase PlayOption { get; private set; }
        public PlayAt PlayAt { get; private set; }
        public Score Score { get; private set; }
        public ClearLamp ClearLamp { get; private set; }
        public Memo Memo { get; private set; }

        public PlayerScore(PlayerId playerId, GameMode gameMode, MusicId musicId, Difficulty difficulty, PlayOptionBase playOption, PlayAt playAt, Score score, ClearLamp clearLamp, Memo memo)
        {
            PlayerId = playerId ?? throw new ArgumentNullException(nameof(playerId));
            GameMode = gameMode ?? throw new ArgumentNullException(nameof(gameMode)); ;
            MusicId = musicId ?? throw new ArgumentNullException(nameof(musicId));
            Difficulty = difficulty ?? throw new ArgumentNullException(nameof(difficulty));
            PlayOption = playOption ?? throw new ArgumentNullException(nameof(playOption)); ;
            PlayAt = playAt ?? throw new ArgumentNullException(nameof(playAt));
            Score = score ?? throw new ArgumentNullException(nameof(score));
            ClearLamp = clearLamp ?? throw new ArgumentNullException(nameof(clearLamp));
            Memo = memo ?? throw new ArgumentNullException(nameof(memo));
        }
        private PlayerScore() { }
    }
}
