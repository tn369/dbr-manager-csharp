namespace Domain.ValueObjects
{
    public sealed record EXScore(Judge PikaGreat, Judge Great) : IComparable<EXScore>
    {
        public ushort Value => (ushort)(PikaGreat.Value * 2 + Great.Value);

        public Judge PikaGreat { get; private set; } = PikaGreat;
        public Judge Great { get; private set; } = Great;

        public int CompareTo(EXScore? other)
        {
            if (other == null) return 1;

            return Value.CompareTo(other.Value);
        }

        public static bool operator >(EXScore left, EXScore right) => left.CompareTo(right) > 0;
        public static bool operator <(EXScore left, EXScore right) => left.CompareTo(right) < 0;
        public static bool operator >=(EXScore left, EXScore right) => left.CompareTo(right) >= 0;
        public static bool operator <=(EXScore left, EXScore right) => left.CompareTo(right) <= 0;
    }
}
