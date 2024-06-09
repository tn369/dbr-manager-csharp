namespace Domain.ValueObjects
{
    public record GameVersionId
    {
        public int Value { get; }

        public GameVersionId(int value)
        {
            if (value <= 0) throw new ArgumentException("GameVersionId must be greater than 0.");
            Value = value;
        }
    }

}
