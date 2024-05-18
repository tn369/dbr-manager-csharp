namespace Domain.ValueObjects
{
    public record Great
    {
        public int Value { get; }

        public Great(int value)
        {
            if (value < 0) throw new ArgumentException("Great cannot be negative.");
            Value = value;
        }
    }

}
