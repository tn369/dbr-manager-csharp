namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // GameVersion Tests
    public class GameVersionTests
    {
        [Fact]
        public void GameVersion_CanBeCreated_WithValidParameters()
        {
            var versionId = new GameVersionId(1);
            var name = new GameVersionName("GameVersion 1");

            var version = new GameVersion(versionId, name);

            Assert.Equal(versionId, version.GameVersionId);
            Assert.Equal(name, version.Name);
        }
    }
}
