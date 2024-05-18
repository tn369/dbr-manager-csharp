namespace Domain.ValueObjects
{

    public record VersionName
    {
        public string Value { get; }

        public VersionName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("VersionName cannot be null or empty.");
            Value = value;
        }
    }

}
