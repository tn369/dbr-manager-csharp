
namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // Music Tests
    public sealed class MusicTests
    {
        [Fact]
        public void Music_CanBeCreated_WithValidParameters()
        {
            var versionId = new GameVersionId(1);
            var title = new MusicTitle("Title");
            var genre = new Genre("Genre");
            var artist = new Artist("Artist");

            var music = new Music(versionId, title, genre, artist);

            Assert.Equal(versionId, music.GameVersionId);
            Assert.Equal(title, music.Title);
            Assert.Equal(genre, music.Genre);
            Assert.Equal(artist, music.Artist);
        }
    }
}
