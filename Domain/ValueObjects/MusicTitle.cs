namespace Domain.ValueObjects
{
    public record MusicTitle
    {
        public string Value { get; }

        public MusicTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("MusicTitle cannot be null or empty.");
            Value = value;
        }
    }
}
