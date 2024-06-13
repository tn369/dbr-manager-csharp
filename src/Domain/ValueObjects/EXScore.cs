namespace Domain.ValueObjects
{
    public sealed record EXScore : IComparable<EXScore>
    {
        public ushort Value => (ushort)(PikaGreat.Value * 2 + Great.Value);

        public Judge PikaGreat { get; private set; }
        public Judge Great { get; private set; }

        public EXScore(Judge pikaGreat, Judge great)
        {
            PikaGreat = pikaGreat ?? throw new ArgumentNullException(nameof(pikaGreat));
            Great = great ?? throw new ArgumentNullException(nameof(great));
        }

        public int CompareTo(EXScore? other)
        {
            if (other == null) return 1;

            return Value.CompareTo(other.Value);
        }

        public static bool operator >(EXScore? left, EXScore? right)
        {
            if (ReferenceEquals(left, right)) return false;
            if (left is null) return false;
            if (right is null) return true;
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(EXScore? left, EXScore? right)
        {
            if (ReferenceEquals(left, right)) return false;
            if (left is null) return true;
            if (right is null) return false;
            return left.CompareTo(right) < 0;
        }

        public static bool operator >=(EXScore? left, EXScore? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null) return false;
            if (right is null) return true;
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <=(EXScore? left, EXScore? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null) return true;
            if (right is null) return false;
            return left.CompareTo(right) <= 0;
        }
    }
}
