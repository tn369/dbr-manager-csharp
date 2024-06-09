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

        [Fact]
        public void Notes_Addition_WorksCorrectly()
        {
            var notes1 = new Notes(10);
            var notes2 = new Notes(20);
            var result = notes1 + notes2;

            Assert.Equal(30, result.Value);
        }

        [Fact]
        public void Notes_Comparison_WorksCorrectly()
        {
            var notes1 = new Notes(10);
            var notes2 = new Notes(20);

            Assert.True(notes2 > notes1);
            Assert.True(notes2 >= notes1);
            Assert.True(notes1 < notes2);
            Assert.True(notes1 <= notes2);
        }

        [Fact]
        public void Notes_Sum_WorksCorrectly()
        {
            var notes1 = new Notes(10);
            var notes2 = new Notes(20);
            var notes3 = new Notes(5);
            var result = Notes.Sum(notes1, notes2, notes3);

            Assert.Equal(35, result.Value);
        }
    }
}
