using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class EXScoreTests
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
    }

}
