namespace Domain.ValueObjects
{
    public sealed record Judge
    {
        public ushort Value { get; }

        public Judge(ushort value)
        {
            Value = value;
        }
    }

}
