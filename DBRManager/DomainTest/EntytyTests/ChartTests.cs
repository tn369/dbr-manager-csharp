namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // Chart Tests
    public class ChartTests
    {
        [Fact]
        public void Chart_CanBeCreated_WithValidParameters()
        {
            var musicId = new MusicId("music123");
            var difficultyId = new DifficultyId(1);
            var level = new Level(10);
            var bpm = new Bpm(150);
            var notesTotal = new NotesTotal(1000);
            var notesScratch = new NotesScratch(50);
            var notesCharge = new NotesCharge(20);
            var notesBackspin = new NotesBackspin(10);

            var chart = new Chart(musicId, difficultyId, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin);

            Assert.Equal(musicId, chart.MusicId);
            Assert.Equal(difficultyId, chart.DifficultyId);
            Assert.Equal(level, chart.Level);
            Assert.Equal(bpm, chart.Bpm);
            Assert.Equal(notesTotal, chart.NotesTotal);
            Assert.Equal(notesScratch, chart.NotesScratch);
            Assert.Equal(notesCharge, chart.NotesCharge);
            Assert.Equal(notesBackspin, chart.NotesBackspin);
        }
    }
}
