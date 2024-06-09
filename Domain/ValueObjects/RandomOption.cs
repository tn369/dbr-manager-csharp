using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record RandomOption
    {
        public RandomOptionType Arrangement { get; private set; }

        public RandomOption(RandomOptionType arrangement)
        {
            Arrangement = arrangement;
        }

        public string GetName()
        {
            return Arrangement switch
            {
                RandomOptionType.Normal => "Normal",
                RandomOptionType.Random => "Random",
                RandomOptionType.RRandom => "R-Random",
                RandomOptionType.SRandom => "S-Random",
                RandomOptionType.HRandom => "H-Random",
                RandomOptionType.Mirror => "Mirror",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
