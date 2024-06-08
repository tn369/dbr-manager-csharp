using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // NotesBackspin Tests
    public class NotesBackspinTests
    {
        [Fact]
        public void NotesBackspin_CannotBeNegative()
        {
            var exception = Assert.Throws<ArgumentException>(() => new NotesBackspin(-1));
            Assert.Equal("NotesBackspin cannot be negative.", exception.Message);
        }

        [Fact]
        public void NotesBackspin_CanBeCreated_WithValidValue()
        {
            var notesBackspin = new NotesBackspin(20);
            Assert.Equal(20, notesBackspin.Value);
        }
    }
}
