using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class ArtistTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetArtist()
        {
            var value = "ArtistName";
            var artist = new Artist(value);
            Assert.Equal(value, artist.Value);
        }

        [Fact]
        public void Constructor_NullOrEmptyValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Artist(null));
            Assert.Throws<ArgumentException>(() => new Artist(""));
        }
    }
}
