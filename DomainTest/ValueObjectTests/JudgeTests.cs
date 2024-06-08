using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // Judge Tests
    public class JudgeTests
    {
        [Fact]
        public void Judge_CanBeCreated_WithValidValue()
        {
            var great = new Judge(200);
            Assert.Equal(200, great.Value);
        }
    }
}
