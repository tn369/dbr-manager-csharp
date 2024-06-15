using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public sealed class ScoreTests
    {
        [Fact]
        public void Score_Constructor_ShouldInitializeProperties()
        {
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var bp = new Judge(10);
            var comboBreak = new Judge(5);
            var score = new Score(exScore, bp, comboBreak);

            Assert.Equal(exScore, score.EXScore);
            Assert.Equal(bp, score.Bp);
            Assert.Equal(comboBreak, score.ComboBreak);
        }

        [Fact]
        public void ComboBreak_CanBeNull()
        {
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var bp = new Judge(10);
            var score = new Score(exScore, bp, null);

            Assert.Null(score.ComboBreak);
        }

        [Fact]
        public void Constructor_WithNullExScore_ShouldThrowArgumentNullException()
        {
            var bp = new Judge(10);
            var comboBreak = new Judge(5);

            Assert.Throws<ArgumentNullException>(() => new Score(null, bp, comboBreak));
        }

        [Fact]
        public void Constructor_WithNullBp_ShouldThrowArgumentNullException()
        {
            var exScore = new EXScore(new Judge(100), new Judge(50));
            var comboBreak = new Judge(5);

            Assert.Throws<ArgumentNullException>(() => new Score(exScore, null, comboBreak));
        }
    }
}
