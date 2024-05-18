using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Chart(MusicId musicId, DifficultyId difficultyId, Level level, Bpm bpm, NotesTotal notesTotal, NotesScratch notesScratch, NotesCharge notesCharge, NotesBackspin notesBackspin)
    {
        public MusicId MusicId { get; private set; } = musicId;
        public DifficultyId DifficultyId { get; private set; } = difficultyId;
        public Level Level { get; private set; } = level;
        public Bpm Bpm { get; private set; } = bpm;
        public NotesTotal NotesTotal { get; private set; } = notesTotal;
        public NotesScratch NotesScratch { get; private set; } = notesScratch;
        public NotesCharge NotesCharge { get; private set; } = notesCharge;
        public NotesBackspin NotesBackspin { get; private set; } = notesBackspin;
    }

}
