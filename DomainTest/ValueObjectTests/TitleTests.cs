using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public sealed class TitleTests
    {
        [Fact]
        public void NULLの場合エラー()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new Title(value));
            Assert.Contains("Title を null または空白にすることはできません。", exception.Message);
        }

        [Fact]
        public void スペースの場合エラー()
        {
            string value = "   ";

            var exception = Assert.Throws<ArgumentException>(() => new Title(value));
            Assert.Contains("Title を null または空白にすることはできません。", exception.Message);
        }
    }
}
