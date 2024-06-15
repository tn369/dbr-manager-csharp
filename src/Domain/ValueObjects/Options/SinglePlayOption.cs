namespace Domain.ValueObjects.Options
{
    public record SinglePlayOption : PlayOptionBase
    {
        public RandomOption PlayerOption { get; init; }

        public SinglePlayOption(bool autoScratch, bool legacyNote, RandomOption playerOption)
            : base(autoScratch, legacyNote, flip: false)
        {
            ArgumentNullException.ThrowIfNull(playerOption);
            PlayerOption = playerOption;
        }
    }
}