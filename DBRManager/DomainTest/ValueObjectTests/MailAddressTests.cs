using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class MailAddressTests
    {
        [Fact]
        public void NULLの場合エラー()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress を null または空白にすることはできません。", exception.Message);
        }

        [Fact]
        public void スペースの場合エラー()
        {
            string value = "   ";

            var exception = Assert.Throws<ArgumentException>(() => new MailAddress(value));
            Assert.Contains("MailAddress を null または空白にすることはできません。", exception.Message);
        }
    }
}
