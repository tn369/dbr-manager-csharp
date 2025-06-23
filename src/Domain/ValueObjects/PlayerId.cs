namespace Domain.ValueObjects
{
    public sealed record PlayerId
    {
        public string Value { get; }

        public PlayerId(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("PlayerId must not be null or empty.");
            Value = value;
        }
    }
}
