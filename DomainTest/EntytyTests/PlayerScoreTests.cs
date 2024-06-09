﻿using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.EntytyTests
{
    public class PlayerScoreTests
    {
        [Fact]
        public void CreatePlayerScore_WithValidData_ShouldSucceed()
        {
            // Arrange
            var playerId = new PlayerId(1);
            var musicId = new MusicId(1);
            var difficulty = new Difficulty(DifficultyType.Another);
            var playAt = new PlayAt(DateTime.UtcNow);
            var gameMode = new GameMode(GameModeType.Double);
            var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var gameSettings = new PlaySettings(gameMode, commonOption, playerOption);
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var bp = new Judge(10);
            var comboBreak = new Judge(5);
            var score = new Score(exScore, bp, comboBreak);
            var clearLamp = new ClearLamp(ClearLampType.FullCombo);
            var memo = new Memo("Great play!");

            // Act
            var playerScore = new PlayerScore(playerId, musicId, difficulty, playAt, gameSettings, score, clearLamp, memo);

            // Assert
            Assert.Equal(playerId, playerScore.PlayerId);
            Assert.Equal(musicId, playerScore.MusicId);
            Assert.Equal(difficulty, playerScore.Difficulty);
            Assert.Equal(playAt, playerScore.PlayAt);
            Assert.Equal(gameSettings, playerScore.PlaySettings);
            Assert.Equal(score, playerScore.Score);
            Assert.Equal(clearLamp, playerScore.ClearLamp);
            Assert.Equal(memo, playerScore.Memo);
        }
    }
}
