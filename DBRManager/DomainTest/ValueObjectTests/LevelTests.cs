using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class LevelTests
    {
        [Fact]
        public void Level_MustBeAtLeastOne()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Level(0));
            Assert.Equal("Level must be at least 1.", exception.Message);
        }

        [Fact]
        public void Level_MustBeAtMostTwelve()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Level(13));
            Assert.Equal("Level must be at most 12.", exception.Message);
        }

        [Fact]
        public void Level_CanBeCreated_WithValidValue()
        {
            var level = new Level(5);
            Assert.Equal(5, level.Value);
        }
    }
}