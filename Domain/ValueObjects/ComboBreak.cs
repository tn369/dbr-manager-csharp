namespace Domain.ValueObjects
{
    public record ComboBreak
    {
        public int Value { get; }

        public ComboBreak(int value)
        {
            if (value < 0) throw new ArgumentException("ComboBreak cannot be negative.");
            Value = value;
        }
    }

}
