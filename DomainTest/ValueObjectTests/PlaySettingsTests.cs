namespace DomainTest.ValueObjectTests
{
    using Domain.Enums;
    using Domain.ValueObjects;
    using System;
    using Xunit;

    public class PlaySettingsTests
    {
        [Fact]
        public void CreatePlaySettings_WithSingleMode_ShouldSucceed()
        {
            // Arrange
            var gameMode = new GameModeStatus(GameMode.Single);
            var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: false);
            var playerOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Normal));

            // Act
            var playSettings = new PlaySettings(gameMode, commonOption, playerOption);

            // Assert
            Assert.Equal(gameMode, playSettings.Mode);
            Assert.Equal(commonOption, playSettings.CommonOption);
            Assert.Equal(playerOption, playSettings.PlayerOption);
            Assert.Null(playSettings.LeftOption);
            Assert.Null(playSettings.RightOption);
        }

        [Fact]
        public void CreatePlaySettings_WithDoubleMode_ShouldSucceed()
        {
            // Arrange
            var gameMode = new GameModeStatus(GameMode.Double);
            var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: true);
            var leftOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Mirror));
            var rightOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Random));

            // Act
            var playSettings = new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption);

            // Assert
            Assert.Equal(gameMode, playSettings.Mode);
            Assert.Equal(commonOption, playSettings.CommonOption);
            Assert.Null(playSettings.PlayerOption);
            Assert.Equal(leftOption, playSettings.LeftOption);
            Assert.Equal(rightOption, playSettings.RightOption);
        }

        [Fact]
        public void CreatePlaySettings_WithBattleMode_ShouldSucceed()
        {
            // Arrange
            var gameMode = new GameModeStatus(GameMode.Battle);
            var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: false);
            var leftOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Normal));
            var rightOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Mirror));

            // Act
            var playSettings = new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption);

            // Assert
            Assert.Equal(gameMode, playSettings.Mode);
            Assert.Equal(commonOption, playSettings.CommonOption);
            Assert.Null(playSettings.PlayerOption);
            Assert.Equal(leftOption, playSettings.LeftOption);
            Assert.Equal(rightOption, playSettings.RightOption);
        }

        [Fact]
        public void CreatePlaySettings_WithBattleModeAndFlipOn_ShouldFail()
        {
            // Arrange
            var gameMode = new GameModeStatus(GameMode.Battle);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: true);
                var leftOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Normal));
                var rightOption = new SideOption(new NoteArrangementStatus(NoteArrangement.Mirror));
                var playSettings = new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption);
            });
        }
    }
}
