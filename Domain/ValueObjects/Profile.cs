namespace Domain.ValueObjects
{
    public sealed record Profile
    {
        public string Value { get; }

        public Profile(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
