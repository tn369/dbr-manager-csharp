namespace Domain.ValueObjects
{
    public record Judge
    {
        public ushort Value { get; }

        public Judge(ushort value)
        {
            Value = value;
        }
    }

}
