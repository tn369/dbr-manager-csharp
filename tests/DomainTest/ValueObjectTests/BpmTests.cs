using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class BpmTests
    {
        [Fact]
        public void Bpm_MustBeGreaterThanZero()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Bpm((ushort)0));
            Assert.Equal("Bpm must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Bpm_CanBeCreated_WithValidValue()
        {
            var bpm = new Bpm((ushort)120);
            Assert.Equal(120, bpm.Value);
        }
    }
}
