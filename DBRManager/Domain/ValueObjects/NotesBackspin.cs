namespace Domain.ValueObjects
{
    public record NotesBackspin
    {
        public int Value { get; }

        public NotesBackspin(int value)
        {
            if (value < 0) throw new ArgumentException("NotesBackspin cannot be negative.");
            Value = value;
        }
    }

}
