namespace Domain.ValueObjects.Options
{
    public record BattlePlayOption : PlayOptionBase
    {
        public RandomOption LeftOption { get; init; }
        public RandomOption RightOption { get; init; }

        public BattlePlayOption(bool autoScratch, bool legacyNote, RandomOption leftOption, RandomOption rightOption)
            : base(autoScratch, legacyNote, flip: false)
        {
            ArgumentNullException.ThrowIfNull(leftOption);
            ArgumentNullException.ThrowIfNull(rightOption);
            LeftOption = leftOption;
            RightOption = rightOption;
        }
    }
}