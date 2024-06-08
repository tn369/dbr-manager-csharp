using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // Bpm Tests
    public class BpmTests
    {
        [Fact]
        public void Bpm_MustBeGreaterThanZero()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Bpm(0));
            Assert.Equal("Bpm must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Bpm_CanBeCreated_WithValidValue()
        {
            var bpm = new Bpm(120);
            Assert.Equal(120, bpm.Value);
        }
    }
}
