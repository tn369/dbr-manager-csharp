﻿namespace Domain.ValueObjects
{
    public record Artist
    {
        public string Value { get; }

        public Artist(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Artist cannot be null or empty.");
            Value = value;
        }
    }

}