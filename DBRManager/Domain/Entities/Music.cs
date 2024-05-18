﻿using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Music(MusicId musicId, VersionId versionId, MusicTitle title, Genre genre, Artist artist)
    {
        public MusicId MusicId { get; private set; } = musicId;
        public VersionId VersionId { get; private set; } = versionId;
        public MusicTitle Title { get; private set; } = title;
        public Genre Genre { get; private set; } = genre;
        public Artist Artist { get; private set; } = artist;
    }

}
