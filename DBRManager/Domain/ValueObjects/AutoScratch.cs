namespace Domain.ValueObjects
{
    public record AutoScratch
    {
        public bool Value { get; }

        public AutoScratch(bool value)
        {
            Value = value;
        }
    }

}
