using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class PlayerNameTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetPlayerName()
        {
            var value = "PlayerName";
            var playerName = new PlayerName(value);
            Assert.Equal(value, playerName.Value);
        }

        [Fact]
        public void Constructor_NullOrEmptyValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new PlayerName(null));
            Assert.Throws<ArgumentException>(() => new PlayerName(""));
            Assert.Throws<ArgumentException>(() => new PlayerName("  "));
        }
    }
}
