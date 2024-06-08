
namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // Music Tests
    public class MusicTests
    {
        [Fact]
        public void Music_CanBeCreated_WithValidParameters()
        {
            var musicId = new MusicId("music123");
            var versionId = new VersionId(1);
            var title = new MusicTitle("Title");
            var genre = new Genre("Genre");
            var artist = new Artist("Artist");

            var music = new Music(musicId, versionId, title, genre, artist);

            Assert.Equal(musicId, music.MusicId);
            Assert.Equal(versionId, music.VersionId);
            Assert.Equal(title, music.Title);
            Assert.Equal(genre, music.Genre);
            Assert.Equal(artist, music.Artist);
        }
    }
}
