namespace Domain.ValueObjects
{
    public sealed record Genre
    {
        public string Value { get; }

        public Genre(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
    }
}
