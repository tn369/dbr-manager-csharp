namespace Domain.ValueObjects
{
    public sealed record Notes : IComparable<Notes>
    {
        public ushort Value { get; }

        public Notes(ushort value)
        {
            Value = value;
        }
        public static Notes operator +(Notes a, Notes b) => new((ushort)(a.Value + b.Value));

        public int CompareTo(Notes? other)
        {
            if (other == null) return 1;

            return Value.CompareTo(other.Value);
        }

        public static bool operator >(Notes? left, Notes? right)
        {
            if (ReferenceEquals(left, right)) return false;
            if (left is null) return false;
            if (right is null) return true;
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(Notes? left, Notes? right)
        {
            if (ReferenceEquals(left, right)) return false;
            if (left is null) return true;
            if (right is null) return false;
            return left.CompareTo(right) < 0;
        }

        public static bool operator >=(Notes? left, Notes? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null) return false;
            if (right is null) return true;
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <=(Notes? left, Notes? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null) return true;
            if (right is null) return false;
            return left.CompareTo(right) <= 0;
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
        public Notes BattleValue()
        {
            return new Notes((ushort)(Value * 2));
        }
    }
}
