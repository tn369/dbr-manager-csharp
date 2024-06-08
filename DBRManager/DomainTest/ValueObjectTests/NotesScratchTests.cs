using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // NotesScratch Tests
    public class NotesScratchTests
    {
        [Fact]
        public void NotesScratch_CannotBeNegative()
        {
            var exception = Assert.Throws<ArgumentException>(() => new NotesScratch(-1));
            Assert.Equal("NotesScratch cannot be negative.", exception.Message);
        }

        [Fact]
        public void NotesScratch_CanBeCreated_WithValidValue()
        {
            var notesScratch = new NotesScratch(100);
            Assert.Equal(100, notesScratch.Value);
        }
    }
}
