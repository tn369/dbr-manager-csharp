namespace Domain.ValueObjects
{
    public record NotesTotal
    {
        public int Value { get; }

        public NotesTotal(int value)
        {
            if (value < 0) throw new ArgumentException("NotesTotal cannot be negative.");
            Value = value;
        }
    }

}
