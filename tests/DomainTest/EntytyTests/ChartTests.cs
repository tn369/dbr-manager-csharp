using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.EntityTests
{
    public sealed class ChartTests
    {
        [Fact]
        public void Chart_CanBeCreated_WithValidParameters()
        {
            var musicId = new MusicId(1);
            var gameMode = new GameMode(GameModeType.Double);
            var difficulty = new Difficulty(DifficultyType.Another);
            var level = new Level(10);
            var bpm = new Bpm(150);
            var notesTotal = new Notes(1000);
            var notesScratch = new Notes(50);
            var notesCharge = new Notes(20);
            var notesBackspin = new Notes(10);

            var chart = new Chart(musicId, gameMode, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin);

            Assert.Equal(musicId, chart.MusicId);
            Assert.Equal(gameMode, chart.GameMode);
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
            var gameMode = new GameMode(GameModeType.Double);
            var difficulty = new Difficulty(DifficultyType.Another);
            var level = new Level(5);
            var bpm = new Bpm(120);
            var notesTotal = new Notes(30);
            var notesScratch = new Notes(10);
            var notesCharge = new Notes(20);
            var notesBackspin = new Notes(15);

            Assert.Throws<ArgumentException>(() => new Chart(musicId, gameMode, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin));
        }

        [Fact]
        public void Chart_ShouldThrowException_AnyArgumentIsNull()
        {
            var musicId = new MusicId(1);
            var gameMode = new GameMode(GameModeType.Double);
            var difficulty = new Difficulty(DifficultyType.Another);
            var level = new Level(10);
            var bpm = new Bpm(150);
            var notesTotal = new Notes(1000);
            var notesScratch = new Notes(50);
            var notesCharge = new Notes(20);
            var notesBackspin = new Notes(10);

            Assert.Throws<ArgumentNullException>(() => new Chart(null, gameMode, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, null, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, gameMode, null, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, gameMode, difficulty, null, bpm, notesTotal, notesScratch, notesCharge, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, gameMode, difficulty, level, null, notesTotal, notesScratch, notesCharge, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, gameMode, difficulty, level, bpm, null, notesScratch, notesCharge, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, gameMode, difficulty, level, bpm, notesTotal, null, notesCharge, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, gameMode, difficulty, level, bpm, notesTotal, notesScratch, null, notesBackspin));
            Assert.Throws<ArgumentNullException>(() => new Chart(musicId, gameMode, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, null));
        }

        [Fact]
        public void ToBattleChart_ShouldConvertSingleChartToBattleChart()
        {
            var musicId = new MusicId(1);
            var gameMode = new GameMode(GameModeType.Single);
            var difficulty = new Difficulty(DifficultyType.Another);
            var level = new Level(10);
            var bpm = new Bpm(150);
            var notesTotal = new Notes(1000);
            var notesScratch = new Notes(50);
            var notesCharge = new Notes(20);
            var notesBackspin = new Notes(10);
            var chart = new Chart(musicId, gameMode, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin);
            var battleChart = chart.ToBattleChart();

            Assert.Equal(musicId, battleChart.MusicId);
            Assert.Equal(GameModeType.Battle, battleChart.GameMode.Value);
            Assert.Equal(difficulty, battleChart.Difficulty);
            Assert.Equal(level, battleChart.Level);
            Assert.Equal(bpm, battleChart.Bpm);
            Assert.Equal(notesTotal.BattleValue(), battleChart.NotesTotal);
            Assert.Equal(notesScratch.BattleValue(), battleChart.NotesScratch);
            Assert.Equal(notesCharge.BattleValue(), battleChart.NotesCharge);
            Assert.Equal(notesBackspin.BattleValue(), battleChart.NotesBackspin);
        }

        [Fact]
        public void ToBattleChart_ShouldThrowException_WhenNotSingleChart()
        {
            var musicId = new MusicId(1);
            var gameMode = new GameMode(GameModeType.Double);
            var difficulty = new Difficulty(DifficultyType.Another);
            var level = new Level(10);
            var bpm = new Bpm(150);
            var notesTotal = new Notes(1000);
            var notesScratch = new Notes(50);
            var notesCharge = new Notes(20);
            var notesBackspin = new Notes(10);
            var chart = new Chart(musicId, gameMode, difficulty, level, bpm, notesTotal, notesScratch, notesCharge, notesBackspin);

            Assert.Throws<ArgumentException>(() => chart.ToBattleChart());
        }
    }
}
