namespace Domain.ValueObjects
{
    public record NotesCharge
    {
        public int Value { get; }

        public NotesCharge(int value)
        {
            if (value < 0) throw new ArgumentException("NotesCharge cannot be negative.");
            Value = value;
        }
    }

}
