namespace Domain.ValueObjects
{
    public sealed record Bpm
    {
        public ushort Value { get; }

        public Bpm(ushort value)
        {
            if (value <= 0) throw new ArgumentException("Bpm must be greater than 0.");
            Value = value;
        }
    }
}
