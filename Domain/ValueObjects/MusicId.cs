namespace Domain.ValueObjects
{
    public sealed record MusicId(int Value)
    {
        public int Value { get; } = Value;
    }
}
