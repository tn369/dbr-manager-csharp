namespace Domain.ValueObjects
{
    public record PlayerId
    {
        public int Value { get; }

        public PlayerId(int value)
        {
            if (value <= 0) throw new ArgumentException("PlayerId must be greater than 0.");
            Value = value;
        }
    }
}
