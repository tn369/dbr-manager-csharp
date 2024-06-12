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
            ArgumentNullException.ThrowIfNull(mode);
            ArgumentNullException.ThrowIfNull(commonOption);
            if (mode.Value == GameModeType.Single)
            {
                if (leftOption != null || rightOption != null)
                {
                    throw new ArgumentException("Single mode cannot have left or right options.");
                }
                ArgumentNullException.ThrowIfNull(playerOption);
            }

            if (mode.Value == GameModeType.Battle)
            {
                if (commonOption.Flip)
                {
                    throw new ArgumentException("Flip option must be OFF in Battle mode.");
                }
                ArgumentNullException.ThrowIfNull(leftOption);
                ArgumentNullException.ThrowIfNull(rightOption);
            }

            Mode = mode;
            CommonOption = commonOption;
            PlayerOption = playerOption;
            LeftOption = leftOption;
            RightOption = rightOption;
        }
    }
}
