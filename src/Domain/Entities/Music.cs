using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Music
    {
        public MusicId Id { get; private set; } = null!;
        public MusicTitle Title { get; private set; } = null!;
        public Artist Artist { get; private set; } = null!;
        public Genre Genre { get; private set; } = null!;
        public Bpm Bpm { get; private set; } = null!;

        public Music(MusicTitle title, Artist artist, Genre genre, Bpm bpm)
        {
            Id = new MusicId(0);
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Artist = artist ?? throw new ArgumentNullException(nameof(artist));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            Bpm = bpm ?? throw new ArgumentNullException(nameof(bpm));
        }

        public void ChangeTitle(MusicTitle title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public void ChangeArtist(Artist artist)
        {
            Artist = artist ?? throw new ArgumentNullException(nameof(artist));
        }

        public void ChangeGenre(Genre genre)
        {
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
        }

        public void ChangeBpm(Bpm bpm)
        {
            Bpm = bpm ?? throw new ArgumentNullException(nameof(bpm));
        }

        private Music() { }
    }
}
