namespace Domain.ValueObjects
{
    public record NotesScratch
    {
        public int Value { get; }

        public NotesScratch(int value)
        {
            if (value < 0) throw new ArgumentException("NotesScratch cannot be negative.");
            Value = value;
        }
    }

}
