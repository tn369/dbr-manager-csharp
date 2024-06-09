namespace Domain.ValueObjects
{

    public sealed record GameVersionName
    {
        public string Value { get; }

        public GameVersionName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("GameVersionName cannot be null or empty.");
            Value = value;
        }
    }

}
