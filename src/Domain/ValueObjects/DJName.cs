namespace Domain.ValueObjects
{
    public sealed record DJName
    {
        public string Value { get; }

        public DJName(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
    }
}
