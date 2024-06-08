namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.Enums;
    using Domain.ValueObjects;
    using System;
    using Xunit;

    namespace YourProject.Tests
    {
        public class PlayerScoreTests
        {
            [Fact]
            public void CreatePlayerScore_WithValidData_ShouldSucceed()
            {
                // Arrange
                var playerId = new PlayerId(1);
                var musicId = new MusicId(1);
                var difficultyId = new DifficultyId(1);
                var playAt = new PlayAt(DateTime.UtcNow);
                var gameMode = new GameModeStatus(GameMode.Double);
                var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: false);
                var playerOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Normal));
                var gameSettings = new PlaySettings(gameMode, commonOption, playerOption);
                var legacy = new Legacy(false);
                var autoScratch = new AutoScratch(false);
                var pikaGreat = new Judge(100);
                var great = new Judge(50);
                var bp = new Judge(10);
                var comboBreak = new ComboBreak(5);
                var clearLampStatus = new ClearLampStatus(ClearLamp.FullCombo);
                var memo = new Memo("Great play!");

                // Act
                var playerScore = new PlayerScore(playerId, musicId, difficultyId, playAt, gameSettings, legacy, autoScratch, pikaGreat, great, bp, comboBreak, clearLampStatus, memo);

                // Assert
                Assert.Equal(playerId, playerScore.PlayerId);
                Assert.Equal(musicId, playerScore.MusicId);
                Assert.Equal(difficultyId, playerScore.DifficultyId);
                Assert.Equal(playAt, playerScore.PlayAt);
                Assert.Equal(gameSettings, playerScore.PlaySettings);
                Assert.Equal(legacy, playerScore.Legacy);
                Assert.Equal(autoScratch, playerScore.AutoScratch);
                Assert.Equal(pikaGreat, playerScore.PikaGreat);
                Assert.Equal(great, playerScore.Great);
                Assert.Equal(bp, playerScore.Bp);
                Assert.Equal(comboBreak, playerScore.ComboBreak);
                Assert.Equal(clearLampStatus, playerScore.ClearLampStatus);
                Assert.Equal(memo, playerScore.Memo);
            }
        }
    }

}
