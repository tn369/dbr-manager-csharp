namespace Domain.ValueObjects
{
    public sealed record MusicId
    {
        public int Value { get; private set; }
        public MusicId(int value)
        {
            if (value <= 0) throw new ArgumentException("MusicId must be greater than 0.");
            Value = value;
        }
    }
}
