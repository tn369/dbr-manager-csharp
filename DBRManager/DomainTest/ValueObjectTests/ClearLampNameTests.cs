using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // ClearLampName Tests
    public class ClearLampNameTests
    {
        [Fact]
        public void ClearLampName_CannotBeNullOrEmpty()
        {
            string value = null;
            var exception = Assert.Throws<ArgumentException>(() => new ClearLampName(value));
            Assert.Equal("ClearLampName cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void ClearLampName_CanBeCreated_WithValidValue()
        {
            string value = "LampName";
            var clearLampName = new ClearLampName(value);
            Assert.Equal(value, clearLampName.Value);
        }
    }
}
