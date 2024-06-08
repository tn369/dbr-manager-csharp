using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // Notes Tests
    public class NotesTests
    {
        [Fact]
        public void Notes_CanBeCreated_WithValidValue()
        {
            var notesTotal = new Notes(1000);
            Assert.Equal(1000, notesTotal.Value);
        }
    }
}
