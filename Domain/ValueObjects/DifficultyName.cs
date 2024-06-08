namespace Domain.ValueObjects
{
    public record DifficultyName
    {
        public string Value { get; }

        public DifficultyName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("DifficultyName cannot be null or empty.");
            Value = value;
        }
    }

}
