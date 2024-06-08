using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class GameModeStatusTests
    {
        [Theory]
        [InlineData(GameMode.Single, "Single")]
        [InlineData(GameMode.Double, "Double")]
        [InlineData(GameMode.Battle, "Battle")]
        public void GetName_ShouldReturnCorrectName(GameMode mode, string expectedName)
        {
            // Arrange
            var gameModeStatus = new GameModeStatus(mode);

            // Act
            var actualName = gameModeStatus.GetName();

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void GetName_ShouldThrowArgumentOutOfRangeException_ForUnknownGameMode()
        {
            // Arrange
            var invalidMode = (GameMode)999;
            var gameModeStatus = new GameModeStatus(invalidMode);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => gameModeStatus.GetName());
        }
    }
}
