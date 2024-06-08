using Domain.ValueObjects;

namespace Domain.Entities
{
    public class PlayerScore
    {
        public PlayerId PlayerId { get; private set; }
        public MusicId MusicId { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public PlayAt PlayAt { get; private set; }
        public PlaySettings PlaySettings { get; private set; }
        public Judge PikaGreat { get; private set; }
        public Judge Great { get; private set; }
        public Judge Bp { get; private set; }
        public Judge ComboBreak { get; private set; }
        public ClearLampStatus ClearLampStatus { get; private set; }
        public Memo Memo { get; private set; }

        public PlayerScore(PlayerId playerId, MusicId musicId, Difficulty difficulty, PlayAt playAt, PlaySettings playSettings, Judge pikaGreat, Judge great, Judge bp, Judge comboBreak, ClearLampStatus clearLampStatus, Memo memo)
        {
            PlayerId = playerId;
            MusicId = musicId;
            Difficulty = difficulty;
            PlayAt = playAt;
            PlaySettings = playSettings;
            PikaGreat = pikaGreat;
            Great = great;
            Bp = bp;
            ComboBreak = comboBreak;
            ClearLampStatus = clearLampStatus;
            Memo = memo;
        }
    }
}
