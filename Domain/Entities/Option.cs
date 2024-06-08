using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Option(OptionId optionId, OptionName name)
    {
        public OptionId OptionId { get; private set; } = optionId;
        public OptionName Name { get; private set; } = name;
    }

}
