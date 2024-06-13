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
            // Arrange
            var difficulty = new Difficulty(difficultyType);

            // Act
            var displayName = difficulty.GetDisplayName();

            // Assert
            Assert.Equal(expectedDisplayName, displayName);
        }

        [Fact]
        public void GetDisplayName_ShouldThrowArgumentOutOfRangeException_ForInvalidDifficultyType()
        {
            // Arrange
            var invalidDifficultyType = (DifficultyType)(-1);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Difficulty(invalidDifficultyType));
        }
    }
}
