using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record PalyOption(bool AutoScratch, bool LegacyNote, bool Flip)
    {
        public PalyOption WithAutoScratch(bool autoScratch) => this with { AutoScratch = autoScratch };
        public PalyOption WithLegacyNote(bool legacyNote) => this with { LegacyNote = legacyNote };
        public PalyOption WithFlip(bool flip) => this with { Flip = flip };

        public static PalyOption Create(GameModeStatus mode, bool autoScratch, bool legacyNote, bool flip)
        {
            if (mode.Mode == GameMode.Battle)
            {
                return new PalyOption(autoScratch, legacyNote, Flip: false);
            }

            if (mode.Mode == GameMode.Single)
            {
                return new PalyOption(autoScratch, legacyNote, Flip: false);
            }

            return new PalyOption(autoScratch, legacyNote, flip);
        }
    }

}
