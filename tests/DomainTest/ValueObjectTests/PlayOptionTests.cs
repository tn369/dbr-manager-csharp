using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class PlayOptionTests
    {
        [Theory]
        [InlineData(GameModeType.Battle, true, true, true, false)]
        [InlineData(GameModeType.Single, true, true, true, false)]
        [InlineData(GameModeType.Double, true, true, true, true)]
        public void Create_ShouldReturnCorrectPlayOption(GameModeType mode, bool autoScratch, bool legacyNote, bool flip, bool expectedFlip)
        {
            // Arrange
            var gameMode = new GameMode(mode);

            // Act
            var playOption = PlayOption.Create(gameMode, autoScratch, legacyNote, flip);

            // Assert
            Assert.Equal(autoScratch, playOption.AutoScratch);
            Assert.Equal(legacyNote, playOption.LegacyNote);
            Assert.Equal(expectedFlip, playOption.Flip);
        }

        [Fact]
        public void WithAutoScratch_ShouldReturnNewPlayOptionWithUpdatedAutoScratch()
        {
            var playOption = PlayOption.Create(new GameMode(GameModeType.Double), false, true, true);
            var newPlayOption = playOption.WithAutoScratch(true);

            Assert.True(newPlayOption.AutoScratch);
            Assert.Equal(playOption.LegacyNote, newPlayOption.LegacyNote);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
        }

        [Fact]
        public void WithLegacyNote_ShouldReturnNewPlayOptionWithUpdatedLegacyNote()
        {
            var playOption = PlayOption.Create(new GameMode(GameModeType.Double), true, false, true);
            var newPlayOption = playOption.WithLegacyNote(true);

            Assert.True(newPlayOption.LegacyNote);
            Assert.Equal(playOption.AutoScratch, newPlayOption.AutoScratch);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
        }

        [Fact]
        public void WithFlip_ShouldReturnNewPlayOptionWithUpdatedFlip()
        {
            var playOption = PlayOption.Create(new GameMode(GameModeType.Double), true, true, false);
            var newPlayOption = playOption.WithFlip(true);

            Assert.True(newPlayOption.Flip);
            Assert.Equal(playOption.AutoScratch, newPlayOption.AutoScratch);
            Assert.Equal(playOption.LegacyNote, newPlayOption.LegacyNote);
        }
    }
}
