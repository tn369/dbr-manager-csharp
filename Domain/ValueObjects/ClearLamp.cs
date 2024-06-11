using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record ClearLamp
    {
        public ClearLampType Value { get; }

        public ClearLamp(ClearLampType value)
        {
            if (!Enum.IsDefined(typeof(ClearLampType), value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Unknown ClearLampType: {value}");
            }
            Value = value;
        }

        public string GetDisplayName()
        {
            return Value switch
            {
                ClearLampType.Failed => "Failed",
                ClearLampType.AssistClear => "Assist Clear",
                ClearLampType.EasyClear => "Easy Clear",
                ClearLampType.Clear => "Clear",
                ClearLampType.HardClear => "Hard Clear",
                ClearLampType.EXHardClear => "EX Hard Clear",
                ClearLampType.FullCombo => "Full Combo",
                ClearLampType.Perfect => "Perfect",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"Unknown ClearLampType: {Value}"),
            };
        }
    }
}
