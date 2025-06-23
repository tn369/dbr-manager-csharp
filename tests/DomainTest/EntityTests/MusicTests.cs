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
            var title = new MusicTitle("Title");
            var artist = new Artist("Artist");
            var genre = new Genre("Genre");
            var bpm = new Bpm((ushort)140);

            var music = new Music(title, artist, genre, bpm);

            Assert.Equal(title, music.Title);
            Assert.Equal(artist, music.Artist);
            Assert.Equal(genre, music.Genre);
            Assert.Equal(artist, music.Artist);
        }

        [Fact]
        public void MusicId_IsNotNull_WhenCreated()
        {
            var title = new MusicTitle("Title");
            var artist = new Artist("Artist");
            var genre = new Genre("Genre");
            var bpm = new Bpm((ushort)140);

            var music = new Music(title, artist, genre, bpm);

            Assert.NotNull(music.Id);
        }

        [Fact]
        public void Music_CannotBeCreated_WithNullParameters()
        {
            Assert.Throws<ArgumentNullException>(() => new Music(null!, new Artist("Artist"), new Genre("Genre"), new Bpm((ushort)140)));
            Assert.Throws<ArgumentNullException>(() => new Music(new MusicTitle("Title"), null!, new Genre("Genre"), new Bpm((ushort)140)));
            Assert.Throws<ArgumentNullException>(() => new Music(new MusicTitle("Title"), new Artist("Artist"), null!, new Bpm((ushort)140)));
            Assert.Throws<ArgumentNullException>(() => new Music(new MusicTitle("Title"), new Artist("Artist"), new Genre("Genre"), null!));
        }
    }
}
