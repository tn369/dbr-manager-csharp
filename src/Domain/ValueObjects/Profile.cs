namespace Domain.ValueObjects
{
    public sealed record Profile
    {
        public string Value { get; }

        public Profile(string value)
        {
            ArgumentNullException.ThrowIfNull(value);
            Value = value;
        }
    }
}
