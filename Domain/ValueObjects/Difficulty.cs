using Domain.Enums;

namespace Domain.ValueObjects
{
    public record Difficulty
    {
        public DifficultyType Value { get; }

        public Difficulty(DifficultyType value)
        {
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
                _ => throw new ArgumentOutOfRangeException(nameof(Value), "Unknown Difficulty Type"),
            };
        }
    }
}
