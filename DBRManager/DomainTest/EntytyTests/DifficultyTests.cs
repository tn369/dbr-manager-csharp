
namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // Difficulty Tests
    public class DifficultyTests
    {
        [Fact]
        public void Difficulty_CanBeCreated_WithValidParameters()
        {
            var difficultyId = new DifficultyId(1);
            var name = new DifficultyName("Hard");

            var difficulty = new Difficulty(difficultyId, name);

            Assert.Equal(difficultyId, difficulty.DifficultyId);
            Assert.Equal(name, difficulty.Name);
        }
    }
}
