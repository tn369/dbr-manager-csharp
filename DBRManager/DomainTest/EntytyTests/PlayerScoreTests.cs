namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using System;
    using Xunit;

    // PlayerScore Tests
    public class PlayerScoreTests
    {
        [Fact]
        public void PlayerScore_CanBeCreated_WithValidParameters()
        {
            var playerId = new PlayerId(1);
            var musicId = new MusicId("music123");
            var difficultyId = new DifficultyId(1);
            var playAt = new PlayAt(DateTime.Now);
            var optionIdLeft = new OptionId(1);
            var optionIdRight = new OptionId(2);
            var legacy = new Legacy(true);
            var autoScratch = new AutoScratch(false);
            var pikaGreat = new PikaGreat(100);
            var great = new Great(200);
            var bp = new Bp(10);
            var comboBreak = new ComboBreak(5);
            var clearLampId = new ClearLampId(1);
            var memo = new Memo("Test Memo");

            var playerScore = new PlayerScore(playerId, musicId, difficultyId, playAt, optionIdLeft, optionIdRight, legacy, autoScratch, pikaGreat, great, bp, comboBreak, clearLampId, memo);

            Assert.Equal(playerId, playerScore.PlayerId);
            Assert.Equal(musicId, playerScore.MusicId);
            Assert.Equal(difficultyId, playerScore.DifficultyId);
            Assert.Equal(playAt, playerScore.PlayAt);
            Assert.Equal(optionIdLeft, playerScore.OptionIdLeft);
            Assert.Equal(optionIdRight, playerScore.OptionIdRight);
            Assert.Equal(legacy, playerScore.Legacy);
            Assert.Equal(autoScratch, playerScore.AutoScratch);
            Assert.Equal(pikaGreat, playerScore.PikaGreat);
            Assert.Equal(great, playerScore.Great);
            Assert.Equal(bp, playerScore.Bp);
            Assert.Equal(comboBreak, playerScore.ComboBreak);
            Assert.Equal(clearLampId, playerScore.ClearLampId);
            Assert.Equal(memo, playerScore.Memo);
        }
    }
}
