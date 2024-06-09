namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.Enums;
    using Domain.ValueObjects;
    using Xunit;

    // Chart Tests
    public sealed class ChartTests
    {
        [Fact]
        public void Chart_CanBeCreated_WithValidParameters()
        {
            var musicId = new MusicId(1);
            var difficulty = new Difficulty(DifficultyType.Another);
            var level = new Level(10);
            var bpm = new Bpm(150);
            var notesTotal = new Notes(1000);
            var notesScratch = new Notes(50);
            var notesCharge = new Notes(20);
            var notesBackspin = new Notes(10);

            var chart = new Chart(musicId, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin);

            Assert.Equal(musicId, chart.MusicId);
            Assert.Equal(difficulty, chart.Difficulty);
            Assert.Equal(level, chart.Level);
            Assert.Equal(bpm, chart.Bpm);
            Assert.Equal(notesTotal, chart.NotesTotal);
            Assert.Equal(notesScratch, chart.NotesScratch);
            Assert.Equal(notesCharge, chart.NotesCharge);
            Assert.Equal(notesBackspin, chart.NotesBackspin);
        }

        [Fact]
        public void Chart_InvalidNotes_ThrowsArgumentException()
        {
            var musicId = new MusicId(1);
            var difficulty = new Difficulty(DifficultyType.Another);
            var level = new Level(5);
            var bpm = new Bpm(120);
            var notesTotal = new Notes(30);
            var notesScratch = new Notes(10);
            var notesCharge = new Notes(20);
            var notesBackspin = new Notes(15);

            Assert.Throws<ArgumentException>(() => new Chart(musicId, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin));
        }
    }
}
