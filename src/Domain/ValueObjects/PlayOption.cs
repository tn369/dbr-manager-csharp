using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record PlayOption
    {
        public bool AutoScratch { get; private set; }
        public bool LegacyNote { get; private set; }
        public bool Flip { get; private set; }

        public PlayOption WithAutoScratch(bool autoScratch) => this with { AutoScratch = autoScratch };
        public PlayOption WithLegacyNote(bool legacyNote) => this with { LegacyNote = legacyNote };
        public PlayOption WithFlip(bool flip) => this with { Flip = flip };

        public static PlayOption Create(GameMode mode, bool autoScratch, bool legacyNote, bool flip)
        {
            ArgumentNullException.ThrowIfNull(mode);
            if (mode.Value != GameModeType.Double)
            {
                return new PlayOption(autoScratch, legacyNote, Flip: false);
            }

            return new PlayOption(autoScratch, legacyNote, flip);
        }
        private PlayOption(bool AutoScratch, bool LegacyNote, bool Flip)
        {
            this.AutoScratch = AutoScratch;
            this.LegacyNote = LegacyNote;
            this.Flip = Flip;
        }
        private PlayOption() { }
    }
}
