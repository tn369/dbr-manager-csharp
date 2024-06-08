namespace Domain.ValueObjects
{
    public record Notes
    {
        public ushort Value { get; }

        public Notes(ushort value)
        {
            Value = value;
        }
    }

}
