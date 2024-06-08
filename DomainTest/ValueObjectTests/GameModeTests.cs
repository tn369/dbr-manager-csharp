using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class GameModeTests
    {
        [Theory]
        [InlineData(GameModeType.Single, "Single")]
        [InlineData(GameModeType.Double, "Double")]
        [InlineData(GameModeType.Battle, "Battle")]
        public void GetName_ShouldReturnCorrectName(GameModeType mode, string expectedName)
        {
            // Arrange
            var gameMode = new GameMode(mode);

            // Act
            var actualName = gameMode.GetName();

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void GetName_ShouldThrowArgumentOutOfRangeException_ForUnknownGameMode()
        {
            // Arrange
            var invalidMode = (GameModeType)999;
            var gameMode = new GameMode(invalidMode);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => gameMode.GetName());
        }
    }
}
