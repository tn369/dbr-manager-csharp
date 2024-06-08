namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // Option Tests
    public class OptionTests
    {
        [Fact]
        public void Option_CanBeCreated_WithValidParameters()
        {
            var optionId = new OptionId(1);
            var name = new OptionName("OptionName");

            var option = new Option(optionId, name);

            Assert.Equal(optionId, option.OptionId);
            Assert.Equal(name, option.Name);
        }
    }
}
