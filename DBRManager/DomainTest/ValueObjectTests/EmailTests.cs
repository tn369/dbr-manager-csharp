using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // Email Tests
    public class EmailTests
    {
        [Fact]
        public void Email_CannotBeNullOrEmpty()
        {
            string value = null;
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email を null または空白にすることはできません。", exception.Message);
        }

        [Fact]
        public void Email_CanBeCreated_WithValidValue()
        {
            string value = "test@example.com";
            var email = new Email(value);
            Assert.Equal(value, email.Value);
        }

        [Fact]
        public void Email_InvalidFormatThrowsException()
        {
            string value = "invalidEmail";
            var exception = Assert.Throws<ArgumentException>(() => new Email(value));
            Assert.Contains("Email の形式が誤っています。", exception.Message);
        }
    }
}
