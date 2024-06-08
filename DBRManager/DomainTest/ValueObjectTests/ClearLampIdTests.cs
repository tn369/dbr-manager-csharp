using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // ClearLampId Tests
    public class ClearLampIdTests
    {
        [Fact]
        public void ClearLampId_CannotBeLessThanOrEqualToZero()
        {
            var exception = Assert.Throws<ArgumentException>(() => new ClearLampId(0));
            Assert.Equal("ClearLampId must be greater than 0.", exception.Message);
        }

        [Fact]
        public void ClearLampId_CanBeCreated_WithValidValue()
        {
            var clearLampId = new ClearLampId(1);
            Assert.Equal(1, clearLampId.Value);
        }
    }
}
