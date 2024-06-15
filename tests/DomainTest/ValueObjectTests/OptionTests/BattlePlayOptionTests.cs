using Domain.Enums;
using Domain.ValueObjects.Options;
using Xunit;

namespace DomainTest.ValueObjectTests.OptionTests
{
    public class BattlePlayOptionTests
    {
        [Fact]
        public void Create_ShouldReturnCorrectPlayOption()
        {
            var autoScratch = true;
            var legacyNote = true;
            var flip = false;
            var leftOption = new RandomOption(RandomOptionType.Normal);
            var rightOption = new RandomOption(RandomOptionType.Normal);
            var playOption = new BattlePlayOption(autoScratch, legacyNote, leftOption, rightOption);

            Assert.Equal(autoScratch, playOption.AutoScratch);
            Assert.Equal(legacyNote, playOption.LegacyNote);
            Assert.Equal(flip, playOption.Flip);
            Assert.Equal(leftOption, playOption.LeftOption);
            Assert.Equal(rightOption, playOption.RightOption);
        }

        [Fact]
        public void WithAutoScratch_ShouldReturnNewPlayOptionWithUpdatedAutoScratch()
        {
            var playOption = new BattlePlayOption(autoScratch: false, legacyNote: true, new RandomOption(RandomOptionType.Normal), new RandomOption(RandomOptionType.Normal));
            var newPlayOption = playOption with { AutoScratch = true };

            Assert.True(newPlayOption.AutoScratch);
            Assert.Equal(playOption.LegacyNote, newPlayOption.LegacyNote);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
            Assert.Equal(playOption.LeftOption, newPlayOption.LeftOption);
            Assert.Equal(playOption.RightOption, newPlayOption.RightOption);
        }

        [Fact]
        public void WithLegacyNote_ShouldReturnNewPlayOptionWithUpdatedLegacyNote()
        {
            var playOption = new BattlePlayOption(autoScratch: true, legacyNote: false, new RandomOption(RandomOptionType.Normal), new RandomOption(RandomOptionType.Normal));
            var newPlayOption = playOption with { LegacyNote = true };

            Assert.True(newPlayOption.LegacyNote);
            Assert.Equal(playOption.AutoScratch, newPlayOption.AutoScratch);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
            Assert.Equal(playOption.LeftOption, newPlayOption.LeftOption);
            Assert.Equal(playOption.RightOption, newPlayOption.RightOption);
        }
    }
}
