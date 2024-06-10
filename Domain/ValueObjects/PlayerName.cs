namespace Domain.ValueObjects
{
    public sealed record PlayerName
    {
        public string Value { get; }

        public PlayerName(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
    }
}
