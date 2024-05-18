namespace Domain.ValueObjects
{
    public record OptionId
    {
        public int? Value { get; }

        public OptionId(int? value)
        {
            if (value.HasValue && value <= 0) throw new ArgumentException("OptionId must be greater than 0.");
            Value = value;
        }
    }

}
