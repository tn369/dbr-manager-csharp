using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class MemoTests
    {
        [Fact]
        public void Constructor_ValidValue_ShouldSetMemo()
        {
            var value = "This is a memo.";
            var memo = new Memo(value);
            Assert.Equal(value, memo.Value);
        }
    }
}
