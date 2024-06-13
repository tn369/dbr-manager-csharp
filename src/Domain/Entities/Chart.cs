using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Chart
    {
        public MusicId MusicId { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public Level Level { get; private set; }
        public Bpm Bpm { get; private set; }
        public Notes NotesTotal { get; private set; }
        public Notes NotesScratch { get; private set; }
        public Notes NotesCharge { get; private set; }
        public Notes NotesBackspin { get; private set; }

        public Chart(MusicId musicId, Difficulty difficulty, Level level, Bpm bpm, Notes notesTotal, Notes notesScratch, Notes notesCharge, Notes notesBackspin)
        {
            ArgumentNullException.ThrowIfNull(notesTotal);
            ArgumentNullException.ThrowIfNull(notesScratch);
            ArgumentNullException.ThrowIfNull(notesCharge);
            ArgumentNullException.ThrowIfNull(notesBackspin);
            ArgumentNullException.ThrowIfNull(musicId);
            ArgumentNullException.ThrowIfNull(difficulty);
            ArgumentNullException.ThrowIfNull(level);
            ArgumentNullException.ThrowIfNull(bpm);

            if (Notes.Sum(notesScratch, notesCharge, notesBackspin) > notesTotal)
            {
                throw new ArgumentException("NotesScratch, NotesCharge, and NotesBackspin total cannot exceed NotesTotal.");
            }

            MusicId = musicId;
            Difficulty = difficulty;
            Level = level;
            Bpm = bpm;
            NotesTotal = notesTotal;
            NotesScratch = notesScratch;
            NotesCharge = notesCharge;
            NotesBackspin = notesBackspin;
        }
        private Chart() { }
    }
}