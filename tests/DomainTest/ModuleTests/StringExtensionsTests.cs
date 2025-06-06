using Domain.Modules;
using Xunit;

namespace DomainTest.ModuleTests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("１２３４５６７８９０", "1234567890")]
        [InlineData("abc１２３", "abc123")]
        [InlineData("NoNumbers", "NoNumbers")]
        public void ConvertFullToHalfNumbers_ShouldConvertCorrectly(string input, string expected)
        {
            var result = input.ConvertFullToHalfNumbers();
            Assert.Equal(expected, result);
        }
    }
}
