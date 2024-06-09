using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public sealed class ScoreTests
    {
        [Fact]
        public void Score_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var bp = new Judge(10);
            var comboBreak = new Judge(5);

            // Act
            var score = new Score(exScore, bp, comboBreak);

            // Assert
            Assert.Equal(exScore, score.EXScore);
            Assert.Equal(bp, score.Bp);
            Assert.Equal(comboBreak, score.ComboBreak);
        }

        [Fact]
        public void ComboBreak_CanBeNull()
        {
            // Arrange
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var bp = new Judge(10);

            // Act
            var score = new Score(exScore, bp, null);

            // Assert
            Assert.Null(score.ComboBreak);
        }
    }
}
