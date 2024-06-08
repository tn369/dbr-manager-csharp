using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.ValueObjectTests
{
    public class ClearLampTests
    {
        [Theory]
        [InlineData(ClearLampType.Failed, "Failed")]
        [InlineData(ClearLampType.AssistClear, "Assist Clear")]
        [InlineData(ClearLampType.EasyClear, "Easy Clear")]
        [InlineData(ClearLampType.Clear, "Clear")]
        [InlineData(ClearLampType.HardClear, "Hard Clear")]
        [InlineData(ClearLampType.EXHardClear, "EX Hard Clear")]
        [InlineData(ClearLampType.FullCombo, "Full Combo")]
        [InlineData(ClearLampType.Perfect, "Perfect")]
        public void GetDisplayName_ReturnsCorrectDisplayName(ClearLampType clearLampType, string expectedDisplayName)
        {
            // Arrange
            var clearLamp = new ClearLamp(clearLampType);

            // Act
            var displayName = clearLamp.GetDisplayName();

            // Assert
            Assert.Equal(expectedDisplayName, displayName);
        }
    }
}
