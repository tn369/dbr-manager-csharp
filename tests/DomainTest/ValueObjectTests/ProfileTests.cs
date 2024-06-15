using Domain.ValueObjects;
using Xunit;

namespace Domain.ValueObjectsTests
{
    public class ProfileTests
    {
        [Fact]
        public void Profile_ShouldThrowExceptionForNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => new Profile(null));
        }

        [Fact]
        public void Profile_ShouldAcceptEmptyString()
        {
            var profile = new Profile(string.Empty);

            Assert.Equal(string.Empty, profile.Value);
        }

        [Fact]
        public void Profile_ShouldAcceptValidValue()
        {
            var profile = new Profile("Valid profile");

            Assert.Equal("Valid profile", profile.Value);
        }

        [Fact]
        public void Profile_EqualityCheck()
        {
            var profile1 = new Profile("Profile 1");
            var profile2 = new Profile("Profile 1");
            var profile3 = new Profile("Profile 2");

            Assert.Equal(profile1, profile2);
            Assert.NotEqual(profile1, profile3);
        }

        [Fact]
        public void Profile_HashCodeCheck()
        {
            var profile1 = new Profile("Profile 1");
            var profile2 = new Profile("Profile 1");

            Assert.Equal(profile1.GetHashCode(), profile2.GetHashCode());
        }

        [Fact]
        public void Profile_ToStringCheck()
        {
            var profile = new Profile("Profile 1");

            Assert.Equal("Profile 1", profile.Value);
        }
    }
}
