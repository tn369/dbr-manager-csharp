using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class PlayAtTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetPlayAt()
        {
            var value = DateTime.Now;
            var playAt = new PlayAt(value);
            Assert.Equal(value, playAt.Value);
        }

        [Fact]
        public void Constructor_DefaultValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PlayAt(default));
        }
    }
}
