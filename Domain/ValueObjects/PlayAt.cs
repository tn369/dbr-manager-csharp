namespace Domain.ValueObjects
{
    public record PlayAt
    {
        public DateTime Value { get; }

        public PlayAt(DateTime value)
        {
            if (value == default) throw new ArgumentException("PlayAt cannot be default DateTime.");
            Value = value;
        }
    }
}
