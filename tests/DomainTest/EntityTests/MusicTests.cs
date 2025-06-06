using Domain.Entities;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.EntityTests
{
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

        [Fact]
        public void MusicId_IsNull_WhenCreated()
        {
            var versionId = new GameVersionId(1);
            var title = new MusicTitle("Title");
            var genre = new Genre("Genre");
            var artist = new Artist("Artist");

            var music = new Music(versionId, title, genre, artist);

            Assert.Null(music.MusicId);
        }

        [Fact]
        public void Music_CannotBeCreated_WithNullParameters()
        {
            Assert.Throws<ArgumentNullException>(() => new Music(null, new MusicTitle("Title"), new Genre("Genre"), new Artist("Artist")));
            Assert.Throws<ArgumentNullException>(() => new Music(new GameVersionId(1), null, new Genre("Genre"), new Artist("Artist")));
            Assert.Throws<ArgumentNullException>(() => new Music(new GameVersionId(1), new MusicTitle("Title"), null, new Artist("Artist")));
            Assert.Throws<ArgumentNullException>(() => new Music(new GameVersionId(1), new MusicTitle("Title"), new Genre("Genre"), null));
        }
    }
}
