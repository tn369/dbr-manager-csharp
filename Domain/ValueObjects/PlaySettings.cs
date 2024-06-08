using Domain.Enums;

namespace Domain.ValueObjects
{
    public sealed record PlaySettings
    {
        public GameModeStatus Mode { get; }
        public PlayOption CommonOption { get; }
        public SideOption? PlayerOption { get; }
        public SideOption? LeftOption { get; }
        public SideOption? RightOption { get; }
        public PlaySettings(GameModeStatus mode, PlayOption commonOption, SideOption? playerOption = null, SideOption? leftOption = null, SideOption? rightOption = null)
        {
            if (mode.Mode == GameMode.Single && (leftOption != null || rightOption != null))
            {
                throw new ArgumentException("Single mode cannot have left or right options.");
            }

            if (mode.Mode == GameMode.Battle && commonOption.Flip)
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
