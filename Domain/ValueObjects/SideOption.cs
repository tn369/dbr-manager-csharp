namespace Domain.ValueObjects
{
    public sealed record SideOption
    {
        public RandomOption RandomOption { get; private set; }
        public SideOption(RandomOption randomOption)
        {
            ArgumentNullException.ThrowIfNull(randomOption);
            RandomOption = randomOption;
        }
    }
}
