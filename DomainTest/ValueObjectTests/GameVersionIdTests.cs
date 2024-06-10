using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class GameVersionIdTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetGameVersionId()
        {
            var value = 1;
            var gameVersionId = new GameVersionId(value);
            Assert.Equal(value, gameVersionId.Value);
        }

        [Fact]
        public void Constructor_InvalidValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new GameVersionId(0));
        }
    }
}
