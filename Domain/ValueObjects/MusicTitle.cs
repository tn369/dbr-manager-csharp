namespace Domain.ValueObjects
{
    public sealed record MusicTitle
    {
        public string Value { get; }

        public MusicTitle(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
    }
}
