namespace Domain.ValueObjects
{
    public sealed record Title
    {
        public string Value { get; }
        public Title(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
    }
}
