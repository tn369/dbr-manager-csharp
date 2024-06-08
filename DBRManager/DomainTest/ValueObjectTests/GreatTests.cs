using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // Great Tests
    public class GreatTests
    {
        [Fact]
        public void Great_CannotBeNegative()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Great(-1));
            Assert.Equal("Great cannot be negative.", exception.Message);
        }

        [Fact]
        public void Great_CanBeCreated_WithValidValue()
        {
            var great = new Great(200);
            Assert.Equal(200, great.Value);
        }
    }
}
