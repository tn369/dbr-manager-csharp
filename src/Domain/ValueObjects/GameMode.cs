using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record GameMode
    {
        public GameModeType Value { get; }

        public GameMode(GameModeType value)
        {
            if (!Enum.IsDefined(typeof(GameModeType), value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Unknown Game Mode: {value}");
            }
            Value = value;
        }
        public string GetName() => Value switch
        {
            GameModeType.Single => "Single",
            GameModeType.Double => "Double",
            GameModeType.Battle => "Battle",
            _ => throw new ArgumentOutOfRangeException(nameof(Value), $"Unknown Game Mode: {Value}")
        };

        public bool IsSingle() => Value == GameModeType.Single;
        public bool IsDouble() => Value == GameModeType.Double;
        public bool IsBattle() => Value == GameModeType.Battle;
    }
}
