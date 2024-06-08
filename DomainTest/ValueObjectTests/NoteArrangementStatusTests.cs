using Domain.Enums;
using Domain.ValueObjects;
using Xunit;
namespace DomainTest.ValueObjectTests
{
    namespace DomainTests
    {
        public class NoteArrangementStatusTests
        {
            [Theory]
            [InlineData(NoteArrangement.Normal, "Normal")]
            [InlineData(NoteArrangement.Random, "Random")]
            [InlineData(NoteArrangement.RRandom, "R-Random")]
            [InlineData(NoteArrangement.SRandom, "S-Random")]
            [InlineData(NoteArrangement.HRandom, "H-Random")]
            [InlineData(NoteArrangement.Mirror, "Mirror")]
            public void GetName_ShouldReturnCorrectName(NoteArrangement arrangement, string expectedName)
            {
                // Arrange
                var noteArrangementStatus = new NoteArrangementStatus(arrangement);

                // Act
                var actualName = noteArrangementStatus.GetName();

                // Assert
                Assert.Equal(expectedName, actualName);
            }

            [Fact]
            public void GetName_ShouldThrowArgumentOutOfRangeException_ForUnknownNoteArrangement()
            {
                // Arrange
                var invalidArrangement = (NoteArrangement)999;
                var noteArrangementStatus = new NoteArrangementStatus(invalidArrangement);

                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => noteArrangementStatus.GetName());
            }
        }
    }
}
