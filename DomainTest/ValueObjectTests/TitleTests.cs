using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public sealed class TitleTests
    {
        [Fact]
        public void Title_CannotBeNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => new Title(null));
            Assert.Throws<ArgumentException>(() => new Title(""));
            Assert.Throws<ArgumentException>(() => new Title("  "));
        }

        [Fact]
        public void Title_CanBeCreated_WithValidValue()
        {
            string value = "高高度降下低高度開傘";
            var title = new Title(value);
            Assert.Equal(value, title.Value);
        }
    }
}
