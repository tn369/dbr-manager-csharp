using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // MusicId Tests
    public sealed class MusicIdTests
    {
        [Fact]
        public void MusicId_CanBeCreated_WithValidValue()
        {
            var value = 1;
            var musicId = new MusicId(value);
            Assert.Equal(value, musicId.Value);
        }
    }
}
