using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record GameModeStatus(GameMode Mode)
    {
        public string GetName() => Mode switch
        {
            GameMode.Single => "Single",
            GameMode.Double => "Double",
            GameMode.Battle => "Battle",
            _ => throw new ArgumentOutOfRangeException(nameof(Mode), "Unknown Game Mode")
        };
    }

}
