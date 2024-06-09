using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class ScoreTests
    {
        [Fact]
        public void Score_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var pikaGreat = new Judge(100);
            var great = new Judge(50);
            var bp = new Judge(10);
            var comboBreak = new Judge(5);

            // Act
            var score = new Score(pikaGreat, great, bp, comboBreak);

            // Assert
            Assert.Equal(pikaGreat, score.PikaGreat);
            Assert.Equal(great, score.Great);
            Assert.Equal(bp, score.Bp);
            Assert.Equal(comboBreak, score.ComboBreak);
        }

        [Fact]
        public void GetExScore_ShouldReturnCorrectValue()
        {
            // Arrange
            var pikaGreat = new Judge(100);
            var great = new Judge(50);
            var bp = new Judge(10);
            var comboBreak = new Judge(5);
            var score = new Score(pikaGreat, great, bp, comboBreak);

            // Act
            var exScore = score.GetExScore();

            // Assert
            Assert.Equal(250, exScore); // 100 * 2 + 50 = 250
        }

        [Fact]
        public void ComboBreak_CanBeNull()
        {
            // Arrange
            var pikaGreat = new Judge(100);
            var great = new Judge(50);
            var bp = new Judge(10);

            // Act
            var score = new Score(pikaGreat, great, bp, null);

            // Assert
            Assert.Null(score.ComboBreak);
        }
    }
}
