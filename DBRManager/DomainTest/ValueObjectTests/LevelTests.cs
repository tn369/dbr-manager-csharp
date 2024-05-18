using Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace DomainTest.ValueObjectTests
{
    public class LevelTests
    {
        [Fact]
        public void NULL‚Ìê‡ƒGƒ‰[()
        {
            string value = null;

            var exception = Assert.Throws<ArgumentException>(() => new Level(0));
            Assert.Contains("Level ‚ğ null ‚Ü‚½‚Í‹ó”’‚É‚·‚é‚±‚Æ‚Í‚Å‚«‚Ü‚¹‚ñB", exception.Message);
        }

    }
}