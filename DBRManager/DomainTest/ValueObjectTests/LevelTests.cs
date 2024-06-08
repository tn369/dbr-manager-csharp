using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class LevelTests
    {
        [Fact]
        public void NULLの場合エラー()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new Level(0));
            Assert.Contains("Level を null または空白にすることはできません。", exception.Message);
        }

    }
}