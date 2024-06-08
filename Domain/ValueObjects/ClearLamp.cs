using Domain.Enums;

namespace Domain.ValueObjects
{
    public record ClearLampStatus
    {
        public ClearLamp Value { get; }

        public ClearLampStatus(ClearLamp value)
        {
            Value = value;
        }

        public string GetDisplayName()
        {
            return Value switch
            {
                ClearLamp.Failed => "Failed",
                ClearLamp.AssistClear => "Assist Clear",
                ClearLamp.EasyClear => "Easy Clear",
                ClearLamp.Clear => "Clear",
                ClearLamp.HardClear => "Hard Clear",
                ClearLamp.EXHardClear => "EX Hard Clear",
                ClearLamp.FullCombo => "Full Combo",
                ClearLamp.Perfect => "Perfect",
                _ => Value.ToString(),
            };
        }
    }
}
