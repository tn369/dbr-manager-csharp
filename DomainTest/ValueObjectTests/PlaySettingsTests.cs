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
            var gameMode = new GameMode(GameModeType.Single);
            var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));

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
            var gameMode = new GameMode(GameModeType.Double);
            var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: true);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Mirror));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Random));

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
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: false);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

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
            var gameMode = new GameMode(GameModeType.Battle);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var commonOption = new PlayOption(AutoScratch: true, LegacyNote: true, Flip: true);
                var leftOption = new SideOption(new RandomOption(RandomOptionType.Normal));
                var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));
                var playSettings = new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption);
            });
        }
    }
}
