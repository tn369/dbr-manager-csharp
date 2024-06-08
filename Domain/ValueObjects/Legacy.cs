namespace Domain.ValueObjects
{
    public record Legacy
    {
        public bool Value { get; }

        public Legacy(bool value)
        {
            Value = value;
        }
    }

}
