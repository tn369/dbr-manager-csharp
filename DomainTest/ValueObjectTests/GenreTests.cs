using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // Genre Tests
    public sealed class GenreTests
    {
        [Fact]
        public void Genre_CannotBeNullOrEmpty()
        {
            string value = null;
            var exception = Assert.Throws<ArgumentException>(() => new Genre(value));
            Assert.Equal("Genre cannot be null or empty.", exception.Message);
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
