namespace Domain.ValueObjects
{
    public record Notes : IComparable<Notes>
    {
        public ushort Value { get; }

        public Notes(ushort value)
        {
            Value = value;
        }
        public int CompareTo(Notes? other)
        {
            if (other == null) return 1;

            return Value.CompareTo(other.Value);
        }
        public static Notes operator +(Notes a, Notes b) => new((ushort)(a.Value + b.Value));

        public static bool operator >(Notes left, Notes right) => left.CompareTo(right) > 0;
        public static bool operator <(Notes left, Notes right) => left.CompareTo(right) < 0;
        public static bool operator >=(Notes left, Notes right) => left.CompareTo(right) >= 0;
        public static bool operator <=(Notes left, Notes right) => left.CompareTo(right) <= 0;

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
