namespace Domain.ValueObjects
{
    public sealed record Memo
    {
        public string Value { get; }

        public Memo(string value)
        {
            Value = value;
        }
    }
}
