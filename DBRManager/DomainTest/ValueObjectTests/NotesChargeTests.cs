using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    // NotesCharge Tests
    public class NotesChargeTests
    {
        [Fact]
        public void NotesCharge_CannotBeNegative()
        {
            var exception = Assert.Throws<ArgumentException>(() => new NotesCharge(-1));
            Assert.Equal("NotesCharge cannot be negative.", exception.Message);
        }

        [Fact]
        public void NotesCharge_CanBeCreated_WithValidValue()
        {
            var notesCharge = new NotesCharge(50);
            Assert.Equal(50, notesCharge.Value);
        }
    }
}
