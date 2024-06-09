namespace Domain.ValueObjects
{
    public sealed record Salt
    {
        public string Value { get; }

        public Salt(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Salt cannot be null or empty.");
            Value = value;
        }
    }
}
