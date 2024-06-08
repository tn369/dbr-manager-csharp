namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // Rival Tests
    public class RivalTests
    {
        [Fact]
        public void Rival_CanBeCreated_WithValidParameters()
        {
            var playerId = new PlayerId(1);
            var rivalId = new PlayerId(2);

            var rival = new Rival(playerId, rivalId);

            Assert.Equal(playerId, rival.PlayerId);
            Assert.Equal(rivalId, rival.RivalId);
        }
    }
}
