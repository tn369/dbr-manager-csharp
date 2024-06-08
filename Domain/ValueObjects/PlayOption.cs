using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record PlayOption(bool AutoScratch, bool LegacyNote, bool Flip)
    {
        public PlayOption WithAutoScratch(bool autoScratch) => this with { AutoScratch = autoScratch };
        public PlayOption WithLegacyNote(bool legacyNote) => this with { LegacyNote = legacyNote };
        public PlayOption WithFlip(bool flip) => this with { Flip = flip };

        public static PlayOption Create(GameModeStatus mode, bool autoScratch, bool legacyNote, bool flip)
        {
            if (mode.Mode == GameMode.Battle)
            {
                return new PlayOption(autoScratch, legacyNote, Flip: false);
            }

            if (mode.Mode == GameMode.Single)
            {
                return new PlayOption(autoScratch, legacyNote, Flip: false);
            }

            return new PlayOption(autoScratch, legacyNote, flip);
        }
    }
}
