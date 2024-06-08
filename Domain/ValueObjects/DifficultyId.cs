namespace Domain.ValueObjects
{
    public record DifficultyId
    {
        public int Value { get; }

        public DifficultyId(int value)
        {
            if (value <= 0) throw new ArgumentException("DifficultyId must be greater than 0.");
            Value = value;
        }
    }

}
