﻿using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Music
    {
        public MusicId? MusicId { get; private set; }
        public GameVersionId GameVersionId { get; private set; }
        public MusicTitle Title { get; private set; }
        public Genre Genre { get; private set; }
        public Artist Artist { get; private set; }

        public Music(GameVersionId versionId, MusicTitle title, Genre genre, Artist artist)
        {
            GameVersionId = versionId;
            Title = title;
            Genre = genre;
            Artist = artist;
        }
        private Music() { }
    }

}
