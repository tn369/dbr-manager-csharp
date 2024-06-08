using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class ClearLampStatusTests
    {
        [Theory]
        [InlineData(ClearLamp.Failed, "Failed")]
        [InlineData(ClearLamp.AssistClear, "Assist Clear")]
        [InlineData(ClearLamp.EasyClear, "Easy Clear")]
        [InlineData(ClearLamp.Clear, "Clear")]
        [InlineData(ClearLamp.HardClear, "Hard Clear")]
        [InlineData(ClearLamp.EXHardClear, "EX Hard Clear")]
        [InlineData(ClearLamp.FullCombo, "Full Combo")]
        [InlineData(ClearLamp.Perfect, "Perfect")]
        public void GetDisplayName_ReturnsCorrectDisplayName(ClearLamp clearLamp, string expectedDisplayName)
        {
            // Arrange
            var clearLampStatus = new ClearLampStatus(clearLamp);

            // Act
            var displayName = clearLampStatus.GetDisplayName();

            // Assert
            Assert.Equal(expectedDisplayName, displayName);
        }
    }
}
