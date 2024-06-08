using Domain.ValueObjects;

namespace Domain.Entities
{
    public class PlayerScore
    {
        public PlayerId PlayerId { get; private set; }
        public MusicId MusicId { get; private set; }
        public DifficultyId DifficultyId { get; private set; }
        public PlayAt PlayAt { get; private set; }
        public PlaySettings PlaySettings { get; private set; }
        public Legacy Legacy { get; private set; }
        public AutoScratch AutoScratch { get; private set; }
        public Judge PikaGreat { get; private set; }
        public Judge Great { get; private set; }
        public Judge Bp { get; private set; }
        public ComboBreak ComboBreak { get; private set; }
        public ClearLampStatus ClearLampStatus { get; private set; }
        public Memo Memo { get; private set; }

        public PlayerScore(PlayerId playerId, MusicId musicId, DifficultyId difficultyId, PlayAt playAt, PlaySettings playSettings, Legacy legacy, AutoScratch autoScratch, Judge pikaGreat, Judge great, Judge bp, ComboBreak comboBreak, ClearLampStatus clearLampStatus, Memo memo)
        {
            PlayerId = playerId;
            MusicId = musicId;
            DifficultyId = difficultyId;
            PlayAt = playAt;
            PlaySettings = playSettings;
            Legacy = legacy;
            AutoScratch = autoScratch;
            PikaGreat = pikaGreat;
            Great = great;
            Bp = bp;
            ComboBreak = comboBreak;
            ClearLampStatus = clearLampStatus;
            Memo = memo;
        }
    }
}
