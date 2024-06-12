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

        [Fact]
        public void GameVersion_ShouldThrowException_WhenGameVersionIdIsNull()
        {
            var name = new GameVersionName("Test Name");
            var exception = Assert.Throws<ArgumentNullException>(() => new GameVersion(null, name));
            Assert.Contains("Value cannot be null. (Parameter 'gameVersionId')", exception.Message);
        }

        [Fact]
        public void GameVersion_ShouldThrowException_WhenNameIsNull()
        {
            var gameVersionId = new GameVersionId(1);
            var exception = Assert.Throws<ArgumentNullException>(() => new GameVersion(gameVersionId, null));
            Assert.Contains("Value cannot be null. (Parameter 'name')", exception.Message);
        }
    }
}
