using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record Difficulty
    {
        public DifficultyType Value { get; }

        public Difficulty(DifficultyType value)
        {
            if (!Enum.IsDefined(typeof(DifficultyType), value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Unknown Difficulty Type : {value}");
            }
            Value = value;
        }

        public string GetDisplayName()
        {
            return Value switch
            {
                DifficultyType.Beginner => "BEGINNER",
                DifficultyType.Normal => "NORMAL",
                DifficultyType.Hyper => "HYPER",
                DifficultyType.Another => "ANOTHER",
                DifficultyType.Leggendaria => "LEGGENDARIA",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"Unknown Difficulty Type : {Value}"),
            };
        }
    }
}
