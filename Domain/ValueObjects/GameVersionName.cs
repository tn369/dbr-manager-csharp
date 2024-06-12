namespace Domain.ValueObjects
{
    public sealed record GameVersionName
    {
        public string Value { get; }

        public GameVersionName(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
    }
}
