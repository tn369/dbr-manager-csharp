using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Domain.ValueObjects.Options;
using Xunit;

namespace DomainTest.EntityTests
{
    public sealed class PlayerScoreTests
    {
        [Fact]
        public void CreatePlayerScore_WithValidData_ShouldSucceed()
        {
            var playerId = new PlayerId(1);
            var musicId = new MusicId(1);
            var difficulty = new Difficulty(DifficultyType.Another);
            var playAt = new PlayAt(DateTime.UtcNow);
            var gameMode = new GameMode(GameModeType.Double);
            var commonOption = new DoublePlayOption(autoScratch: true, legacyNote: true, flip: true, new RandomOption(RandomOptionType.Normal), new RandomOption(RandomOptionType.Normal));
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var bp = new Judge(10);
            var comboBreak = new Judge(5);
            var score = new Score(exScore, bp, comboBreak);
            var clearLamp = new ClearLamp(ClearLampType.FullCombo);
            var memo = new Memo("Great play!");
            var playerScore = new PlayerScore(playerId, gameMode, musicId, difficulty, commonOption, playAt, score, clearLamp, memo);

            Assert.Equal(playerId, playerScore.PlayerId);
            Assert.Equal(musicId, playerScore.MusicId);
            Assert.Equal(difficulty, playerScore.Difficulty);
            Assert.Equal(playAt, playerScore.PlayAt);
            Assert.Equal(gameMode, playerScore.GameMode);
            Assert.Equal(commonOption, playerScore.PlayOption);
            Assert.Equal(score, playerScore.Score);
            Assert.Equal(clearLamp, playerScore.ClearLamp);
            Assert.Equal(memo, playerScore.Memo);
        }

        [Fact]
        public void PlayerScore_ShouldThrowException_AnyArgumentIsNull()
        {
            var playerId = new PlayerId(1);
            var musicId = new MusicId(1);
            var difficulty = new Difficulty(DifficultyType.Another);
            var playAt = new PlayAt(DateTime.UtcNow);
            var gameMode = new GameMode(GameModeType.Double);
            var commonOption = new DoublePlayOption(autoScratch: true, legacyNote: true, flip: true, new RandomOption(RandomOptionType.Normal), new RandomOption(RandomOptionType.Normal));
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var bp = new Judge(10);
            var comboBreak = new Judge(5);
            var score = new Score(exScore, bp, comboBreak);
            var clearLamp = new ClearLamp(ClearLampType.FullCombo);
            var memo = new Memo("Great play!");

            Assert.Throws<ArgumentNullException>(() => new PlayerScore(null, gameMode, musicId, difficulty, commonOption, playAt, score, clearLamp, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, null, musicId, difficulty, commonOption, playAt, score, clearLamp, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, gameMode, null, difficulty, commonOption, playAt, score, clearLamp, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, gameMode, musicId, null, commonOption, playAt, score, clearLamp, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, gameMode, musicId, difficulty, null, playAt, score, clearLamp, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, gameMode, musicId, difficulty, commonOption, null, score, clearLamp, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, gameMode, musicId, difficulty, commonOption, playAt, null, clearLamp, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, gameMode, musicId, difficulty, commonOption, playAt, score, null, memo));
            Assert.Throws<ArgumentNullException>(() => new PlayerScore(playerId, gameMode, musicId, difficulty, commonOption, playAt, score, clearLamp, null));
        }
    }
}
