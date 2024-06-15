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
            var gameMode = new GameMode(mode);
            var actualName = gameMode.GetName();

            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void GetName_ShouldThrowArgumentOutOfRangeException_ForUnknownGameMode()
        {
            var invalidMode = (GameModeType)999;

            Assert.Throws<ArgumentOutOfRangeException>(() => new GameMode(invalidMode));
        }
    }
}
