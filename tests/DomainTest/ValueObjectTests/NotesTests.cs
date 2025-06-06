using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public sealed class NotesTests
    {
        [Fact]
        public void Notes_CanBeCreated_WithValidValue()
        {
            var notes = new Notes(100);
            Assert.Equal(100, notes.Value);
        }

        [Fact]
        public void Notes_Addition_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            var notes2 = new Notes(50);
            var result = notes1 + notes2;

            Assert.Equal(150, result.Value);
        }

        [Fact]
        public void Notes_CompareTo_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            var notes2 = new Notes(50);
            var notes3 = new Notes(100);

            Assert.True(notes1.CompareTo(notes2) > 0);
            Assert.True(notes2.CompareTo(notes1) < 0);
            Assert.Equal(0, notes1.CompareTo(notes3));
        }

        [Fact]
        public void Notes_Comparison_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            var notes2 = new Notes(50);
            var notes3 = new Notes(100);

            Assert.True(notes1 > notes2);
            Assert.True(notes2 < notes1);
            Assert.True(notes1 >= notes3);
            Assert.True(notes3 <= notes1);
        }

        [Fact]
        public void Notes_NullComparison_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            Notes? notes2 = null;

            Assert.True(notes1.CompareTo(notes2) > 0);
        }

        [Fact]
        public void Notes_NullOperatorComparison_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            Notes? notes2 = null;

            Assert.True(notes1 > notes2);
            Assert.True(notes2 < notes1);
            Assert.False(notes1 < notes2);
            Assert.False(notes2 > notes1);
            Assert.True(notes1 >= notes2);
            Assert.True(notes2 <= notes1);
            Assert.False(notes1 <= notes2);
            Assert.False(notes2 >= notes1);
        }

        [Fact]
        public void Notes_Equality_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            var notes2 = new Notes(100);

            Assert.True(notes1 == notes2);
            Assert.False(notes1 != notes2);
        }

        [Fact]
        public void Notes_Inequality_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            var notes2 = new Notes(50);

            Assert.False(notes1 == notes2);
            Assert.True(notes1 != notes2);
        }

        [Fact]
        public void Notes_ReferenceEquals_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            var notes2 = notes1;

            Assert.False(notes1 > notes2);
            Assert.False(notes1 < notes2);
            Assert.True(notes1 >= notes2);
            Assert.True(notes1 <= notes2);
        }

        [Fact]
        public void Notes_Sum_WorksCorrectly()
        {
            var notes1 = new Notes(100);
            var notes2 = new Notes(50);
            var notes3 = new Notes(25);

            var result = Notes.Sum(notes1, notes2, notes3);
            Assert.Equal(175, result.Value);
        }

        [Fact]
        public void Notes_Sum_WithEmptyArray_ReturnsZero()
        {
            var result = Notes.Sum();
            Assert.Equal(0, result.Value);
        }

        [Fact]
        public void Notes_BattleValue_ShouldReturnDoubleValue()
        {
            var notes = new Notes(200);

            var result = notes.BattleValue();

            Assert.Equal(400, result.Value);
        }
    }
}
