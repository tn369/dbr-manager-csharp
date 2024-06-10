using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class GameVersionNameTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetGameVersionName()
        {
            var value = "VersionName";
            var gameVersionName = new GameVersionName(value);
            Assert.Equal(value, gameVersionName.Value);
        }

        [Fact]
        public void Constructor_NullOrEmptyValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new GameVersionName(null));
            Assert.Throws<ArgumentException>(() => new GameVersionName(""));
        }
    }
}
