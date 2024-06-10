using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class UrlTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetUrl()
        {
            var value = "http://example.com";
            var url = new Url(value);
            Assert.Equal(value, url.Value);
        }

        [Fact]
        public void Constructor_NullOrEmptyValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Url(null));
            Assert.Throws<ArgumentException>(() => new Url(""));
        }
    }
}
