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
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
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
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: true);
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
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
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
        public void CreatePlaySettings_WithNullGameMode_ShouldThrowArgumentNullException()
        {
            // Arrange
            var commonOption = PlayOption.Create(new GameMode(GameModeType.Single), autoScratch: true, legacyNote: true, flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PlaySettings(null, commonOption, playerOption));
        }

        [Fact]
        public void CreatePlaySettings_WithNullCommonOption_ShouldThrowArgumentNullException()
        {
            // Arrange
            var gameMode = new GameMode(GameModeType.Single);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PlaySettings(gameMode, null, playerOption));
        }

        [Fact]
        public void CreatePlaySettings_WithSingleModeAndLeftOption_ShouldThrowArgumentException()
        {
            // Arrange
            var gameMode = new GameMode(GameModeType.Single);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PlaySettings(gameMode, commonOption, playerOption, leftOption));
        }

        [Fact]
        public void CreatePlaySettings_WithSingleModeAndRightOption_ShouldThrowArgumentException()
        {
            // Arrange
            var gameMode = new GameMode(GameModeType.Single);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PlaySettings(gameMode, commonOption, playerOption, rightOption: rightOption));
        }

        [Fact]
        public void CreatePlaySettings_WithBattleModeAndFlipOption_ShouldThrowArgumentException()
        {
            // Arrange
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = PlayOption.Create(new GameMode(GameModeType.Double), autoScratch: true, legacyNote: true, flip: true);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption));
        }

        [Fact]
        public void CreatePlaySettings_WithBattleModeAndNullLeftOption_ShouldThrowArgumentNullException()
        {
            // Arrange
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PlaySettings(gameMode, commonOption, leftOption: null, rightOption: rightOption));
        }

        [Fact]
        public void CreatePlaySettings_WithBattleModeAndNullRightOption_ShouldThrowArgumentNullException()
        {
            // Arrange
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Normal));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: null));
        }
    }
}
