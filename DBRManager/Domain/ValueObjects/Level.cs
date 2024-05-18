namespace Domain.ValueObjects
{
    public record Level
    {
        public int Value { get; }

        public Level(int value)
        {
            if (value < 0) throw new ArgumentException("Level cannot be negative.");
            Value = value;
        }
    }
}
