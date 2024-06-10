using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class MusicTitleTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetMusicTitle()
        {
            var value = "MusicTitle";
            var musicTitle = new MusicTitle(value);
            Assert.Equal(value, musicTitle.Value);
        }

        [Fact]
        public void Constructor_NullOrEmptyValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MusicTitle(null));
            Assert.Throws<ArgumentException>(() => new MusicTitle(""));
        }
    }
}
