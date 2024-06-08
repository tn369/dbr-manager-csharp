using Domain.Enums;

namespace Domain.ValueObjects
{
    public record ClearLampStatus 
    {
        public ClearLamp Value { get; }

        public ClearLampStatus (ClearLamp value)
        {
            Value = value;
        }

        public string GetDisplayName()
        {
            switch (Value)
            {
                case ClearLamp.Failed: return "Failed";
                case ClearLamp.AssistClear: return "Assist Clear";
                case ClearLamp.EasyClear: return "Easy Clear";
                case ClearLamp.Clear: return "Clear";
                case ClearLamp.HardClear: return "Hard Clear";
                case ClearLamp.EXHardClear: return "EX Hard Clear";
                case ClearLamp.FullCombo: return "Full Combo";
                case ClearLamp.Perfect: return "Perfect";
                default: return Value.ToString();
            }
        }
    }
}
