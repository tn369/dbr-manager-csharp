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
            var gameMode = new GameMode(GameModeType.Single);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var playSettings = new PlaySettings(gameMode, commonOption, playerOption);

            Assert.Equal(gameMode, playSettings.Mode);
            Assert.Equal(commonOption, playSettings.CommonOption);
            Assert.Equal(playerOption, playSettings.PlayerOption);
            Assert.Null(playSettings.LeftOption);
            Assert.Null(playSettings.RightOption);
        }

        [Fact]
        public void CreatePlaySettings_WithDoubleMode_ShouldSucceed()
        {
            var gameMode = new GameMode(GameModeType.Double);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: true);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Mirror));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Random));
            var playSettings = new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption);

            Assert.Equal(gameMode, playSettings.Mode);
            Assert.Equal(commonOption, playSettings.CommonOption);
            Assert.Null(playSettings.PlayerOption);
            Assert.Equal(leftOption, playSettings.LeftOption);
            Assert.Equal(rightOption, playSettings.RightOption);
        }

        [Fact]
        public void CreatePlaySettings_WithBattleMode_ShouldSucceed()
        {
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));
            var playSettings = new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption);

            Assert.Equal(gameMode, playSettings.Mode);
            Assert.Equal(commonOption, playSettings.CommonOption);
            Assert.Null(playSettings.PlayerOption);
            Assert.Equal(leftOption, playSettings.LeftOption);
            Assert.Equal(rightOption, playSettings.RightOption);
        }

        [Fact]
        public void CreatePlaySettings_WithNullGameMode_ShouldThrowArgumentNullException()
        {
            var commonOption = PlayOption.Create(new GameMode(GameModeType.Single), autoScratch: true, legacyNote: true, flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));

            Assert.Throws<ArgumentNullException>(() => new PlaySettings(null, commonOption, playerOption));
        }

        [Fact]
        public void CreatePlaySettings_WithNullCommonOption_ShouldThrowArgumentNullException()
        {
            var gameMode = new GameMode(GameModeType.Single);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));

            Assert.Throws<ArgumentNullException>(() => new PlaySettings(gameMode, null, playerOption));
        }

        [Fact]
        public void CreatePlaySettings_WithSingleModeAndLeftOption_ShouldThrowArgumentException()
        {
            var gameMode = new GameMode(GameModeType.Single);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            Assert.Throws<ArgumentException>(() => new PlaySettings(gameMode, commonOption, playerOption, leftOption));
        }

        [Fact]
        public void CreatePlaySettings_WithSingleModeAndRightOption_ShouldThrowArgumentException()
        {
            var gameMode = new GameMode(GameModeType.Single);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var playerOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            Assert.Throws<ArgumentException>(() => new PlaySettings(gameMode, commonOption, playerOption, rightOption: rightOption));
        }

        [Fact]
        public void CreatePlaySettings_WithBattleModeAndFlipOption_ShouldThrowArgumentException()
        {
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = PlayOption.Create(new GameMode(GameModeType.Double), autoScratch: true, legacyNote: true, flip: true);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Normal));
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            Assert.Throws<ArgumentException>(() => new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: rightOption));
        }

        [Fact]
        public void CreatePlaySettings_WithBattleModeAndNullLeftOption_ShouldThrowArgumentNullException()
        {
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var rightOption = new SideOption(new RandomOption(RandomOptionType.Mirror));

            Assert.Throws<ArgumentNullException>(() => new PlaySettings(gameMode, commonOption, leftOption: null, rightOption: rightOption));
        }

        [Fact]
        public void CreatePlaySettings_WithBattleModeAndNullRightOption_ShouldThrowArgumentNullException()
        {
            var gameMode = new GameMode(GameModeType.Battle);
            var commonOption = PlayOption.Create(gameMode, autoScratch: true, legacyNote: true, flip: false);
            var leftOption = new SideOption(new RandomOption(RandomOptionType.Normal));

            Assert.Throws<ArgumentNullException>(() => new PlaySettings(gameMode, commonOption, leftOption: leftOption, rightOption: null));
        }
    }
}
