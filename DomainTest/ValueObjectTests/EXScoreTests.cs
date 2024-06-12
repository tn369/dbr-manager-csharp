using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public sealed class EXScoreTests
    {
        [Fact]
        public void EXScore_GetValue_WorksCorrectly()
        {
            var judgePikaGreat = new Judge(10);
            var judgeGreat = new Judge(20);
            var exScore = new EXScore(judgePikaGreat, judgeGreat);

            Assert.Equal(40, exScore.Value);
        }

        [Fact]
        public void EXScore_Comparison_WorksCorrectly()
        {
            var exScore1 = new EXScore(new Judge(10), new Judge(20)); // Value = 40
            var exScore2 = new EXScore(new Judge(15), new Judge(10)); // Value = 40
            var exScore3 = new EXScore(new Judge(20), new Judge(5));  // Value = 45

            Assert.True(exScore3 > exScore1);
            Assert.True(exScore1 < exScore3);
            Assert.True(exScore1 >= exScore2);
            Assert.True(exScore2 <= exScore1);
        }

        [Fact]
        public void EXScore_CompareTo_WorksCorrectly()
        {
            var exScore1 = new EXScore(new Judge(10), new Judge(20)); // Value = 40
            var exScore2 = new EXScore(new Judge(20), new Judge(10)); // Value = 50

            Assert.True(exScore1.CompareTo(exScore2) < 0);
            Assert.True(exScore2.CompareTo(exScore1) > 0);
            Assert.Equal(0, exScore1.CompareTo(exScore1));
        }

        [Fact]
        public void EXScore_Comparison_BoundaryValues()
        {
            var exScore1 = new EXScore(new Judge(0), new Judge(0)); // Value = 0
            var exScore2 = new EXScore(new Judge(0), new Judge(0)); // Value = 0
            var exScore3 = new EXScore(new Judge(0), new Judge(1)); // Value = 1

            Assert.True(exScore1 >= exScore2);
            Assert.True(exScore1 <= exScore2);
            Assert.True(exScore3 > exScore1);
            Assert.True(exScore3 >= exScore1);
            Assert.True(exScore1 < exScore3);
            Assert.True(exScore1 <= exScore3);
        }

        [Fact]
        public void EXScore_NullComparison_WorksCorrectly()
        {
            var exScore1 = new EXScore(new Judge(10), new Judge(20)); // Value = 40
            EXScore? exScore2 = null;

            Assert.True(exScore1.CompareTo(exScore2) > 0);
        }

        [Fact]
        public void EXScore_NullOperatorComparison_WorksCorrectly()
        {
            var exScore1 = new EXScore(new Judge(10), new Judge(20)); // Value = 40
            EXScore? exScore2 = null;

            Assert.True(exScore1 > exScore2);
            Assert.True(exScore2 < exScore1);
            Assert.False(exScore1 < exScore2);
            Assert.False(exScore2 > exScore1);
            Assert.True(exScore1 >= exScore2);
            Assert.True(exScore2 <= exScore1);
            Assert.False(exScore1 <= exScore2);
            Assert.False(exScore2 >= exScore1);
        }

        [Fact]
        public void EXScore_Equality_WorksCorrectly()
        {
            var exScore1 = new EXScore(new Judge(10), new Judge(20)); // Value = 40
            var exScore2 = new EXScore(new Judge(10), new Judge(20)); // Value = 40

            Assert.True(exScore1 == exScore2);
            Assert.False(exScore1 != exScore2);
        }

        [Fact]
        public void EXScore_Inequality_WorksCorrectly()
        {
            var exScore1 = new EXScore(new Judge(10), new Judge(20)); // Value = 40
            var exScore3 = new EXScore(new Judge(20), new Judge(5));  // Value = 45

            Assert.False(exScore1 == exScore3);
            Assert.True(exScore1 != exScore3);
        }
    }
}
