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

        [Theory]
        [InlineData(GameModeType.Single, true, false, false)]
        [InlineData(GameModeType.Double, false, true, false)]
        [InlineData(GameModeType.Battle, false, false, true)]
        public void IsSingle_IsDouble_IsBattle_ShouldReturnCorrectValues(GameModeType mode, bool expectedIsSingle, bool expectedIsDouble, bool expectedIsBattle)
        {
            var gameMode = new GameMode(mode);

            Assert.Equal(expectedIsSingle, gameMode.IsSingle());
            Assert.Equal(expectedIsDouble, gameMode.IsDouble());
            Assert.Equal(expectedIsBattle, gameMode.IsBattle());
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForUnknownGameMode()
        {
            var invalidMode = (GameModeType)999;

            Assert.Throws<ArgumentOutOfRangeException>(() => new GameMode(invalidMode));
        }
    }
}
