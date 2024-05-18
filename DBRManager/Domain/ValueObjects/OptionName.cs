namespace Domain.ValueObjects
{
    public record OptionName
    {
        public string Value { get; }

        public OptionName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("OptionName cannot be null or empty.");
            Value = value;
        }
    }

}
