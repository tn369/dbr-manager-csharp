using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // IidxId Tests
    public sealed class IidxIdTests
    {
        [Fact]
        public void IidxId_CannotBeNullOrEmpty()
        {
            string value = null;
            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("IidxId を null または空白にすることはできません。", exception.Message);
        }

        [Theory]
        [InlineData("1234-5678")]
        [InlineData("12345678")]
        public void IidxId_CanBeCreated_WithValidValue(string value)
        {
            var iidxId = new IidxId(value);
            Assert.Equal("1234-5678", iidxId.Value);
        }
    }
}