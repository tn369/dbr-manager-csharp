namespace DomainTest.EntityTests
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

        [Fact]
        public void GameVersion_ShouldThrowException_WhenNameIsNull()
        {
            var gameVersionId = new GameVersionId(1);
            var name = new GameVersionName("Test Name");
            Assert.Throws<ArgumentNullException>(() => new GameVersion(null, name));
            Assert.Throws<ArgumentNullException>(() => new GameVersion(gameVersionId, null));
        }
    }
}
