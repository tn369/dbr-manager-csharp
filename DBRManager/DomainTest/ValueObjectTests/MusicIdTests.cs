using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // MusicId Tests
    public class MusicIdTests
    {
        [Fact]
        public void MusicId_CannotBeNullOrEmpty()
        {
            string value = null;
            var exception = Assert.Throws<ArgumentException>(() => new MusicId(value));
            Assert.Equal("MusicId cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void MusicId_CanBeCreated_WithValidValue()
        {
            string value = "validMusicId";
            var musicId = new MusicId(value);
            Assert.Equal(value, musicId.Value);
        }
    }
}
