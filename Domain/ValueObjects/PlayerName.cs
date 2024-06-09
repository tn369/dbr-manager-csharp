namespace Domain.ValueObjects
{
    public sealed record PlayerName
    {
        public string Value { get; }

        public PlayerName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("PlayerName cannot be null or empty.");
            Value = value;
        }
    }
}
