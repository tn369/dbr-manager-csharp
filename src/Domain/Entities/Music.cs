using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Music
    {
        public MusicId? MusicId { get; private set; }
        public GameVersionId GameVersionId { get; private set; } = null!;
        public MusicTitle Title { get; private set; } = null!;
        public Genre Genre { get; private set; } = null!;
        public Artist Artist { get; private set; } = null!;

        public Music(GameVersionId versionId, MusicTitle title, Genre genre, Artist artist)
        {
            GameVersionId = versionId ?? throw new ArgumentNullException(nameof(versionId));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            Artist = artist ?? throw new ArgumentNullException(nameof(artist));
        }
        private Music() { }
    }
}
