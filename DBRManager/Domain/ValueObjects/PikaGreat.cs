namespace Domain.ValueObjects
{
    public record PikaGreat
    {
        public int Value { get; }

        public PikaGreat(int value)
        {
            if (value < 0) throw new ArgumentException("PikaGreat cannot be negative.");
            Value = value;
        }
    }

}
