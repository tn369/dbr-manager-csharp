using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // Genre Tests
    public sealed class GenreTests
    {
        [Fact]
        public void Genre_CannotBeNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => new Genre(null));
            Assert.Throws<ArgumentException>(() => new Genre(""));
            Assert.Throws<ArgumentException>(() => new Genre("  "));
        }

        [Fact]
        public void Genre_CanBeCreated_WithValidValue()
        {
            string value = "Rock";
            var genre = new Genre(value);
            Assert.Equal(value, genre.Value);
        }
    }
}
