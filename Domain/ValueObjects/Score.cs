namespace Domain.ValueObjects
{
    public sealed record Score(EXScore EXScore, Judge Bp, Judge? ComboBreak)
    {
        public EXScore EXScore { get; private set; } = EXScore;
        public Judge Bp { get; private set; } = Bp;
        public Judge? ComboBreak { get; private set; } = ComboBreak;
    };
}
