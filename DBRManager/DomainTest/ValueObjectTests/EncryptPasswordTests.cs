using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // EncryptPassword Tests
    public class EncryptPasswordTests
    {
        [Fact]
        public void EncryptPassword_CannotBeNullOrEmpty()
        {
            string value = null;
            var exception = Assert.Throws<ArgumentException>(() => new EncryptPassword(value));
            Assert.Equal("EncryptPassword cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void EncryptPassword_CanBeCreated_WithValidValue()
        {
            string value = "password";
            var encryptPassword = new EncryptPassword(value);
            Assert.Equal(value, encryptPassword.Value);
        }
    }
}
