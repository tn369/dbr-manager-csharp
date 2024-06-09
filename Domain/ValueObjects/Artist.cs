namespace Domain.ValueObjects
{
    public sealed record Artist
    {
        public string Value { get; }

        public Artist(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Artist cannot be null or empty.");
            Value = value;
        }
    }

}
