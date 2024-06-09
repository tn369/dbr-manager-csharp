using Domain.ValueObjects;
using Xunit;

namespace Domain.Tests
{
    public sealed class EmailTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_ShouldThrowArgumentException_WhenEmailIsNullOrWhitespace(string email)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Email(email));
            Assert.Equal("Email cannot be null or whitespace. (Parameter 'value')", ex.Message);
        }

        [Fact]
        public void Validate_ShouldThrowArgumentException_WhenEmailIsTooLong()
        {
            string longEmail = new string('a', 255) + "@example.com";
            var ex = Assert.Throws<ArgumentException>(() => new Email(longEmail));
            Assert.Equal("Email is too long. (Parameter 'value')", ex.Message);
        }

        [Fact]
        public void Validate_ShouldThrowArgumentException_WhenEmailDoesNotContainAt()
        {
            string invalidEmail = "example.com";
            var ex = Assert.Throws<ArgumentException>(() => new Email(invalidEmail));
            Assert.Equal("Email must contain '@'. (Parameter 'value')", ex.Message);
        }

        [Theory]
        [InlineData(".example@example.com")]
        [InlineData("example@example.com.")]
        public void Validate_ShouldThrowArgumentException_WhenEmailStartsOrEndsWithDot(string email)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Email(email));
            Assert.Equal("Email cannot start or end with '.'. (Parameter 'value')", ex.Message);
        }

        [Theory]
        [InlineData("@example.com")]
        [InlineData("example@")]
        public void Validate_ShouldThrowArgumentException_WhenEmailHasNoLocalOrDomainPart(string email)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Email(email));
            Assert.Equal("Email must have text before and after '@'. (Parameter 'value')", ex.Message);
        }

        [Fact]
        public void Validate_ShouldNotThrowException_WhenEmailIsValid()
        {
            string validEmail = "example@example.com";
            var email = new Email(validEmail);
            Assert.Equal(validEmail, email.Value);
        }
    }
}
