namespace Domain.ValueObjects.Options
{
    public record DoublePlayOption : PlayOptionBase
    {
        public RandomOption LeftOption { get; init; }
        public RandomOption RightOption { get; init; }

        public DoublePlayOption(bool autoScratch, bool legacyNote, bool flip, RandomOption leftOption, RandomOption rightOption)
            : base(autoScratch, legacyNote, flip)
        {
            ArgumentNullException.ThrowIfNull(leftOption);
            ArgumentNullException.ThrowIfNull(rightOption);
            LeftOption = leftOption;
            RightOption = rightOption;
        }
    }
}