using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class LevelTests
    {
        [Fact]
        public void NULL�̏ꍇ�G���[()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new Level(0));
            Assert.Contains("Level �� null �܂��͋󔒂ɂ��邱�Ƃ͂ł��܂���B", exception.Message);
        }

    }
}