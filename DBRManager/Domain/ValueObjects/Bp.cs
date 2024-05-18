namespace Domain.ValueObjects
{
    public record Bp
    {
        public int Value { get; }

        public Bp(int value)
        {
            if (value < 0) throw new ArgumentException("Bp cannot be negative.");
            Value = value;
        }
    }

}
