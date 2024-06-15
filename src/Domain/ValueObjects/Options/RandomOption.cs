using Domain.Enums;

namespace Domain.ValueObjects.Options
{
    public sealed record RandomOption
    {
        public RandomOptionType Value { get; private set; }

        public RandomOption(RandomOptionType value)
        {
            if (!Enum.IsDefined(typeof(RandomOptionType), value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Unknown RandomOptionType: {value}");
            }
            Value = value;
        }

        public string GetName()
        {
            return Value switch
            {
                RandomOptionType.Normal => "Normal",
                RandomOptionType.Random => "Random",
                RandomOptionType.RRandom => "R-Random",
                RandomOptionType.SRandom => "S-Random",
                RandomOptionType.HRandom => "H-Random",
                RandomOptionType.Mirror => "Mirror",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"Unknown RandomOptionType: {Value}"),
            };
        }
    }
}
