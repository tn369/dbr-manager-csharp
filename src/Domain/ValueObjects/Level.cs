namespace Domain.ValueObjects
{
    public sealed record Level
    {
        public int Value { get; }

        public Level(int value)
        {
            if (value < 1) throw new ArgumentException("Level must be at least 1.");
            if (value > 12) throw new ArgumentException("Level must be at most 12.");
            Value = value;
        }
    }
}
