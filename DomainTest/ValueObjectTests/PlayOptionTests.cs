using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{

    public class PlayOptionTests
    {
        [Theory]
        [InlineData(GameMode.Battle, true, true, true, false)]
        [InlineData(GameMode.Single, true, true, true, false)]
        [InlineData(GameMode.Double, true, true, true, true)]
        public void Create_ShouldReturnCorrectPlayOption(GameMode mode, bool autoScratch, bool legacyNote, bool flip, bool expectedFlip)
        {
            // Arrange
            var gameModeStatus = new GameModeStatus(mode);

            // Act
            var playOption = PlayOption.Create(gameModeStatus, autoScratch, legacyNote, flip);

            // Assert
            Assert.Equal(autoScratch, playOption.AutoScratch);
            Assert.Equal(legacyNote, playOption.LegacyNote);
            Assert.Equal(expectedFlip, playOption.Flip);
        }

        [Fact]
        public void WithAutoScratch_ShouldReturnNewPlayOptionWithUpdatedAutoScratch()
        {
            // Arrange
            var playOption = new PlayOption(false, true, true);

            // Act
            var newPlayOption = playOption.WithAutoScratch(true);

            // Assert
            Assert.True(newPlayOption.AutoScratch);
            Assert.Equal(playOption.LegacyNote, newPlayOption.LegacyNote);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
        }

        [Fact]
        public void WithLegacyNote_ShouldReturnNewPlayOptionWithUpdatedLegacyNote()
        {
            // Arrange
            var playOption = new PlayOption(true, false, true);

            // Act
            var newPlayOption = playOption.WithLegacyNote(true);

            // Assert
            Assert.True(newPlayOption.LegacyNote);
            Assert.Equal(playOption.AutoScratch, newPlayOption.AutoScratch);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
        }

        [Fact]
        public void WithFlip_ShouldReturnNewPlayOptionWithUpdatedFlip()
        {
            // Arrange
            var playOption = new PlayOption(true, true, false);

            // Act
            var newPlayOption = playOption.WithFlip(true);

            // Assert
            Assert.True(newPlayOption.Flip);
            Assert.Equal(playOption.AutoScratch, newPlayOption.AutoScratch);
            Assert.Equal(playOption.LegacyNote, newPlayOption.LegacyNote);
        }
    }
}
