using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Chart
    {
        public MusicId MusicId { get; private set; }
        public GameMode GameMode { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public Level Level { get; private set; }
        public Bpm Bpm { get; private set; }
        public Notes NotesTotal { get; private set; }
        public Notes NotesScratch { get; private set; }
        public Notes NotesCharge { get; private set; }
        public Notes NotesBackspin { get; private set; }

        public Chart(MusicId musicId, GameMode gameMode, Difficulty difficulty, Level level, Bpm bpm, Notes notesTotal, Notes notesScratch, Notes notesCharge, Notes notesBackspin)
        {
            ArgumentNullException.ThrowIfNull(musicId);
            ArgumentNullException.ThrowIfNull(gameMode);
            ArgumentNullException.ThrowIfNull(difficulty);
            ArgumentNullException.ThrowIfNull(level);
            ArgumentNullException.ThrowIfNull(bpm);
            ArgumentNullException.ThrowIfNull(notesTotal);
            ArgumentNullException.ThrowIfNull(notesScratch);
            ArgumentNullException.ThrowIfNull(notesCharge);
            ArgumentNullException.ThrowIfNull(notesBackspin);

            if (Notes.Sum(notesScratch, notesCharge, notesBackspin) > notesTotal)
            {
                throw new ArgumentException("NotesScratch, NotesCharge, and NotesBackspin total cannot exceed NotesTotal.");
            }

            MusicId = musicId;
            GameMode = gameMode;
            Difficulty = difficulty;
            Level = level;
            Bpm = bpm;
            NotesTotal = notesTotal;
            NotesScratch = notesScratch;
            NotesCharge = notesCharge;
            NotesBackspin = notesBackspin;
        }

        private Chart() { }

        public Chart ToBattleChart()
        {
            if (!GameMode.IsSingle())
            {
                throw new ArgumentException("Battle chart can only be created from a single chart.");
            }

            return new Chart(
                MusicId,
                new GameMode(GameModeType.Battle),
                Difficulty,
                Level,
                Bpm,
                NotesTotal.BattleValue(),
                NotesScratch.BattleValue(),
                NotesCharge.BattleValue(),
                NotesBackspin.BattleValue()
            );
        }
    }
}