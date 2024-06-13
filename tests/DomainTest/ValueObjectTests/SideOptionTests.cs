using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class SideOptionTests
    {
        [Fact]
        public void SideOption_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var randomOption = new RandomOption(RandomOptionType.Normal);

            // Act
            var sideOption = new SideOption(randomOption);

            // Assert
            Assert.Equal(randomOption, sideOption.RandomOption);
        }

        [Fact]
        public void SideOption_Constructor_WithNullRandomOption_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SideOption(null));
        }
    }
}