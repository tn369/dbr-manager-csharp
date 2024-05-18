using Domain.ValueObjects;

namespace Domain.Entities
{
    public class ClearLamp(ClearLampId clearLampId, ClearLampName name)
    {
        public ClearLampId ClearLampId { get; private set; } = clearLampId;
        public ClearLampName Name { get; private set; } = name;
    }

}
