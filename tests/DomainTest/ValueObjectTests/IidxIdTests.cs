using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public sealed class IidxIdTests
    {
        [Fact]
        public void IidxId_CannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new IidxId(null));
            Assert.Throws<ArgumentException>(() => new IidxId(""));
            Assert.Throws<ArgumentException>(() => new IidxId("   "));
        }

        [Theory]
        [InlineData("1234-5678")]
        [InlineData("12345678")]
        [InlineData(" 1234-5678 ")]
        [InlineData(" 12345678 ")]
        public void IidxId_CanBeCreated_WithValidValue(string value)
        {
            var iidxId = new IidxId(value);
            Assert.Equal("1234-5678", iidxId.Value);
        }

        [Theory]
        [InlineData("abcd-efgh")]
        [InlineData("123-45678")]
        [InlineData("123456789")]
        [InlineData("1234 5678")]
        public void IidxId_CannotBeCreated_WithInvalidValue(string value)
        {
            var exception = Assert.Throws<ArgumentException>(() => new IidxId(value));
            Assert.Contains("Invalid IidxId format.", exception.Message);
        }

        [Fact]
        public void IidxId_FormatsValueCorrectly()
        {
            var iidxId = new IidxId("１２３４５６７８");
            Assert.Equal("1234-5678", iidxId.Value);
        }
    }
}
