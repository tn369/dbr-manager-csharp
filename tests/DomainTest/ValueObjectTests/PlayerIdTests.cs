using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class PlayerIdTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetPlayerId()
        {
            var value = 1;
            var playerId = new PlayerId(value);
            Assert.Equal(value, playerId.Value);
        }

        [Fact]
        public void Constructor_InvalidValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PlayerId(0));
        }
    }
}
