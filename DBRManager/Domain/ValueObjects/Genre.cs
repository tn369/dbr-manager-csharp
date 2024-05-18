namespace Domain.ValueObjects
{
    public record Genre
    {
        public string Value { get; }

        public Genre(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Genre cannot be null or empty.");
            Value = value;
        }
    }

}
