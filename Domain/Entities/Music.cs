using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Music(MusicId musicId, GameVersionId versionId, MusicTitle title, Genre genre, Artist artist)
    {
        public MusicId MusicId { get; private set; } = musicId;
        public GameVersionId GameVersionId { get; private set; } = versionId;
        public MusicTitle Title { get; private set; } = title;
        public Genre Genre { get; private set; } = genre;
        public Artist Artist { get; private set; } = artist;
    }

}
