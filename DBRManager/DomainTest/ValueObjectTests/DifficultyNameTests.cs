using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // DifficultyName Tests
    public class DifficultyNameTests
    {
        [Fact]
        public void DifficultyName_CannotBeNullOrEmpty()
        {
            string value = null;
            var exception = Assert.Throws<ArgumentException>(() => new DifficultyName(value));
            Assert.Equal("DifficultyName cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void DifficultyName_CanBeCreated_WithValidValue()
        {
            string value = "Hard";
            var difficultyName = new DifficultyName(value);
            Assert.Equal(value, difficultyName.Value);
        }
    }
}
