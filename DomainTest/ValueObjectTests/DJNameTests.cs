using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class DJNameTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetDJName()
        {
            var value = "DJName";
            var djName = new DJName(value);
            Assert.Equal(value, djName.Value);
        }

        [Fact]
        public void Constructor_NullOrEmptyValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new DJName(null));
            Assert.Throws<ArgumentException>(() => new DJName(""));
            Assert.Throws<ArgumentException>(() => new DJName("  "));
        }
    }
}
