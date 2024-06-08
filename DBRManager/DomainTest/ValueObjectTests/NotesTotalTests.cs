using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // NotesTotal Tests
    public class NotesTotalTests
    {
        [Fact]
        public void NotesTotal_CannotBeNegative()
        {
            var exception = Assert.Throws<ArgumentException>(() => new NotesTotal(-1));
            Assert.Equal("NotesTotal cannot be negative.", exception.Message);
        }

        [Fact]
        public void NotesTotal_CanBeCreated_WithValidValue()
        {
            var notesTotal = new NotesTotal(1000);
            Assert.Equal(1000, notesTotal.Value);
        }
    }
}
