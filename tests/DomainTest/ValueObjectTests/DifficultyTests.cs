using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace Domain.Tests.ValueObjects
{
    public class DifficultyTests
    {
        [Theory]
        [InlineData(DifficultyType.Beginner, "BEGINNER")]
        [InlineData(DifficultyType.Normal, "NORMAL")]
        [InlineData(DifficultyType.Hyper, "HYPER")]
        [InlineData(DifficultyType.Another, "ANOTHER")]
        [InlineData(DifficultyType.Leggendaria, "LEGGENDARIA")]
        public void GetDisplayName_ShouldReturnCorrectDisplayName(DifficultyType difficultyType, string expectedDisplayName)
        {
            var difficulty = new Difficulty(difficultyType);
            var displayName = difficulty.GetDisplayName();

            Assert.Equal(expectedDisplayName, displayName);
        }

        [Fact]
        public void GetDisplayName_ShouldThrowArgumentOutOfRangeException_ForInvalidDifficultyType()
        {
            var invalidDifficultyType = (DifficultyType)(-1);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Difficulty(invalidDifficultyType));
        }
    }
}
