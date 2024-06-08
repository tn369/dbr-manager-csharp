namespace Domain.ValueObjects
{
    public record VersionId
    {
        public int Value { get; }

        public VersionId(int value)
        {
            if (value <= 0) throw new ArgumentException("VersionId must be greater than 0.");
            Value = value;
        }
    }

}
