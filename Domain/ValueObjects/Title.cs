namespace Domain.ValueObjects
{
    internal sealed record Title
    {
        public Title(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Title を null または空白にすることはできません。", nameof(value));
            }
        }
    }
}
