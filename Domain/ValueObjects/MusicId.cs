namespace Domain.ValueObjects
{
    public record MusicId
    {
        public string Value { get; }

        public MusicId(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("MusicId cannot be null or empty.");
            Value = value;
        }
    }

}
