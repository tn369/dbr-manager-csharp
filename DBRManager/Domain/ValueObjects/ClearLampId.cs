namespace Domain.ValueObjects
{
    public record ClearLampId
    {
        public int Value { get; }

        public ClearLampId(int value)
        {
            if (value <= 0) throw new ArgumentException("ClearLampId must be greater than 0.");
            Value = value;
        }
    }

}
