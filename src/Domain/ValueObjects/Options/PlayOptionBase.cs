namespace Domain.ValueObjects.Options
{
    public abstract record PlayOptionBase
    {
        public bool AutoScratch { get; init; }
        public bool LegacyNote { get; init; }
        public bool Flip { get; init; }

        protected PlayOptionBase(bool autoScratch, bool legacyNote, bool flip)
        {
            AutoScratch = autoScratch;
            LegacyNote = legacyNote;
            Flip = flip;
        }
    }
}