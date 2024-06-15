using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public sealed class MusicIdTests
    {
        [Fact]
        public void MusicId_CanBeCreated_WithValidValue()
        {
            var value = 1;
            var musicId = new MusicId(value);
            Assert.Equal(value, musicId.Value);
        }

        [Fact]
        public void Constructor_InvalidValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MusicId(0));
        }
    }
}
