namespace Domain.ValueObjects
{
    public sealed record Artist
    {
        public string Value { get; }

        public Artist(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
    }

}
