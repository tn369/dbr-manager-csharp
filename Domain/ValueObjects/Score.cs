namespace Domain.ValueObjects
{
    public sealed record Score(Judge PikaGreat, Judge Great, Judge Bp, Judge? ComboBreak)
    {
        public Judge PikaGreat { get; private set; } = PikaGreat;
        public Judge Great { get; private set; } = Great;
        public Judge Bp { get; private set; } = Bp;
        public Judge? ComboBreak { get; private set; } = ComboBreak;

        public ushort GetExScore() => (ushort)(PikaGreat.Value * 2 + Great.Value);
    };
}
