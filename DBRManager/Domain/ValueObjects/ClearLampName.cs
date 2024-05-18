namespace Domain.ValueObjects
{
    public record ClearLampName
    {
        public string Value { get; }

        public ClearLampName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("ClearLampName cannot be null or empty.");
            Value = value;
        }
    }

}
