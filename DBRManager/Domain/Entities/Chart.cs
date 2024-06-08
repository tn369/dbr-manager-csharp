using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Chart(MusicId musicId, DifficultyId difficultyId, Level level, Bpm bpm, Notes notesTotal, Notes notesScratch, Notes notesCharge, Notes notesBackspin)
    {
        public MusicId MusicId { get; private set; } = musicId;
        public DifficultyId DifficultyId { get; private set; } = difficultyId;
        public Level Level { get; private set; } = level;
        public Bpm Bpm { get; private set; } = bpm;
        public Notes NotesTotal { get; private set; } = notesTotal;
        public Notes NotesScratch { get; private set; } = notesScratch;
        public Notes NotesCharge { get; private set; } = notesCharge;
        public Notes NotesBackspin { get; private set; } = notesBackspin;
    }

}
