using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record GameMode(GameModeType Mode)
    {
        public string GetName() => Mode switch
        {
            GameModeType.Single => "Single",
            GameModeType.Double => "Double",
            GameModeType.Battle => "Battle",
            _ => throw new ArgumentOutOfRangeException(nameof(Mode), "Unknown Game Mode")
        };
    }

}
