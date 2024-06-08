using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // DifficultyId Tests
    public class DifficultyIdTests
    {
        [Fact]
        public void DifficultyId_CannotBeLessThanOrEqualToZero()
        {
            var exception = Assert.Throws<ArgumentException>(() => new DifficultyId(0));
            Assert.Equal("DifficultyId must be greater than 0.", exception.Message);
        }

        [Fact]
        public void DifficultyId_CanBeCreated_WithValidValue()
        {
            var difficultyId = new DifficultyId(1);
            Assert.Equal(1, difficultyId.Value);
        }
    }
}
