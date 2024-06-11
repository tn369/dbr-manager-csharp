using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class RandomOptionTests
    {
        [Theory]
        [InlineData(RandomOptionType.Normal, "Normal")]
        [InlineData(RandomOptionType.Random, "Random")]
        [InlineData(RandomOptionType.RRandom, "R-Random")]
        [InlineData(RandomOptionType.SRandom, "S-Random")]
        [InlineData(RandomOptionType.HRandom, "H-Random")]
        [InlineData(RandomOptionType.Mirror, "Mirror")]
        public void GetName_ShouldReturnCorrectName(RandomOptionType value, string expectedName)
        {
            // Arrange
            var randomOption = new RandomOption(value);

            // Act
            var actualName = randomOption.GetName();

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void GetName_ShouldThrowArgumentOutOfRangeException_ForUnknownRandomOption()
        {
            // Arrange
            var invalidValue = (RandomOptionType)999;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new RandomOption(invalidValue));
        }
    }
}
