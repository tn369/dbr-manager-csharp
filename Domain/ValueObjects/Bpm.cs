namespace Domain.ValueObjects
{
    public sealed record Bpm
    {
        public int Value { get; }

        public Bpm(int value)
        {
            if (value <= 0) throw new ArgumentException("Bpm must be greater than 0.");
            Value = value;
        }
    }

}
