namespace Domain.ValueObjects
{
    public record Memo
    {
        public string Value { get; }

        public Memo(string value)
        {
            Value = value;
        }
    }
}
