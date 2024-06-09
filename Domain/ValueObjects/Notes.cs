namespace Domain.ValueObjects
{
    public record Notes
    {
        public ushort Value { get; }

        public Notes(ushort value)
        {
            Value = value;
        }

        public static Notes operator +(Notes a, Notes b)
        {
            return new Notes((ushort)(a.Value + b.Value));
        }

        public static bool operator >(Notes a, Notes b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(Notes a, Notes b)
        {
            return a.Value < b.Value;
        }

        public static Notes Sum(params Notes[] notesArray)
        {
            ushort total = 0;
            foreach (var notes in notesArray)
            {
                total += notes.Value;
            }
            return new Notes(total);
        }
    }
}
