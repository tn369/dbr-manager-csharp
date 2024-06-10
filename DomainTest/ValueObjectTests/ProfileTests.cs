using Domain.ValueObjects;
using Xunit;

namespace Domain.ValueObjectsTests
{
    public class ProfileTests
    {
        [Fact]
        public void Profile_ShouldThrowExceptionForNullValue()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Profile(null));
        }

        [Fact]
        public void Profile_ShouldAcceptEmptyString()
        {
            // Arrange & Act
            var profile = new Profile(string.Empty);

            // Assert
            Assert.Equal(string.Empty, profile.Value);
        }

        [Fact]
        public void Profile_ShouldAcceptValidValue()
        {
            // Arrange & Act
            var profile = new Profile("Valid profile");

            // Assert
            Assert.Equal("Valid profile", profile.Value);
        }

        [Fact]
        public void Profile_EqualityCheck()
        {
            // Arrange
            var profile1 = new Profile("Profile 1");
            var profile2 = new Profile("Profile 1");
            var profile3 = new Profile("Profile 2");

            // Act & Assert
            Assert.Equal(profile1, profile2);
            Assert.NotEqual(profile1, profile3);
        }

        [Fact]
        public void Profile_HashCodeCheck()
        {
            // Arrange
            var profile1 = new Profile("Profile 1");
            var profile2 = new Profile("Profile 1");

            // Act & Assert
            Assert.Equal(profile1.GetHashCode(), profile2.GetHashCode());
        }

        [Fact]
        public void Profile_ToStringCheck()
        {
            // Arrange
            var profile = new Profile("Profile 1");

            // Act & Assert
            Assert.Equal("Profile 1", profile.Value);
        }
    }
}
