
namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    namespace DomainTest
    {
        // ClearLamp Tests
        public class ClearLampTests
        {
            [Fact]
            public void ClearLamp_CanBeCreated_WithValidParameters()
            {
                var clearLampId = new ClearLampId(1);
                var name = new ClearLampName("LampName");

                var clearLamp = new ClearLamp(clearLampId, name);

                Assert.Equal(clearLampId, clearLamp.ClearLampId);
                Assert.Equal(name, clearLamp.Name);
            }
        }
    }

}
