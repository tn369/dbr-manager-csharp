using Domain.Enums;
using Domain.ValueObjects.Options;
using Xunit;

namespace DomainTest.ValueObjectTests.OptionTests
{
    public class SinglePlayOptionTests
    {
        [Fact]
        public void Create_ShouldReturnCorrectPlayOption()
        {
            var autoScratch = true;
            var legacyNote = true;
            var flip = false;
            var playerOption = new RandomOption(RandomOptionType.Normal);
            var playOption = new SinglePlayOption(autoScratch, legacyNote, playerOption);

            Assert.Equal(autoScratch, playOption.AutoScratch);
            Assert.Equal(legacyNote, playOption.LegacyNote);
            Assert.Equal(flip, playOption.Flip);
            Assert.Equal(playerOption, playOption.PlayerOption);
        }

        [Fact]
        public void WithAutoScratch_ShouldReturnNewPlayOptionWithUpdatedAutoScratch()
        {
            var playOption = new SinglePlayOption(autoScratch: false, legacyNote: true, new RandomOption(RandomOptionType.Normal));
            var newPlayOption = playOption with { AutoScratch = true };

            Assert.True(newPlayOption.AutoScratch);
            Assert.Equal(playOption.LegacyNote, newPlayOption.LegacyNote);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
            Assert.Equal(playOption.PlayerOption, newPlayOption.PlayerOption);
        }

        [Fact]
        public void WithLegacyNote_ShouldReturnNewPlayOptionWithUpdatedLegacyNote()
        {
            var playOption = new SinglePlayOption(autoScratch: true, legacyNote: false, new RandomOption(RandomOptionType.Normal));
            var newPlayOption = playOption with { LegacyNote = true };

            Assert.True(newPlayOption.LegacyNote);
            Assert.Equal(playOption.AutoScratch, newPlayOption.AutoScratch);
            Assert.Equal(playOption.Flip, newPlayOption.Flip);
            Assert.Equal(playOption.PlayerOption, newPlayOption.PlayerOption);
        }
    }
}
