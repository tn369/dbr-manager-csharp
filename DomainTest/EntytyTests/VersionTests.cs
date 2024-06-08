namespace DomainTest.EntytyTests
{
    using Domain.ValueObjects;
    using Xunit;

    // Version Tests
    public class VersionTests
    {
        [Fact]
        public void Version_CanBeCreated_WithValidParameters()
        {
            var versionId = new VersionId(1);
            var name = new VersionName("Version 1");

            var version = new Domain.Entities.Version(versionId, name);

            Assert.Equal(versionId, version.VersionId);
            Assert.Equal(name, version.Name);
        }
    }
}
