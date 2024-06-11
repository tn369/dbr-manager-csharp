using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record PlaySettings
    {
        public GameMode Mode { get; }
        public PlayOption CommonOption { get; }
        public SideOption? PlayerOption { get; }
        public SideOption? LeftOption { get; }
        public SideOption? RightOption { get; }
        public PlaySettings(GameMode mode, PlayOption commonOption, SideOption? playerOption = null, SideOption? leftOption = null, SideOption? rightOption = null)
        {
            if (mode.Value == GameModeType.Single && (leftOption != null || rightOption != null))
            {
                throw new ArgumentException("Single mode cannot have left or right options.");
            }

            if (mode.Value == GameModeType.Battle && commonOption.Flip)
            {
                throw new ArgumentException("Flip option must be OFF in Battle mode.");
            }
            Mode = mode;
            CommonOption = commonOption;
            PlayerOption = playerOption;
            LeftOption = leftOption;
            RightOption = rightOption;
        }
    }
}
