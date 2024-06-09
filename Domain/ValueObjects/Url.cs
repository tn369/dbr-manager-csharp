namespace Domain.ValueObjects
{
    public record Url
    {
        public string Value { get; }

        public Url(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Url cannot be null or empty.");
            Value = value;
        }
    }
}
