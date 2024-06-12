namespace Domain.ValueObjects
{
    public sealed record Score
    {
        public EXScore EXScore { get; private set; }
        public Judge Bp { get; private set; }
        public Judge? ComboBreak { get; private set; }
        public Score(EXScore EXScore, Judge Bp, Judge? ComboBreak)
        {
            ArgumentNullException.ThrowIfNull(EXScore);
            ArgumentNullException.ThrowIfNull(Bp);
            this.EXScore = EXScore;
            this.Bp = Bp;
            this.ComboBreak = ComboBreak;
        }
    };
}
