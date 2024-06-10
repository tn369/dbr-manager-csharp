namespace DomainTest.EntytyTests
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Xunit;

    // Player Tests
    public class PlayerTests
    {
        [Fact]
        public void Player_CanBeCreated_WithValidParameters()
        {
            var playerId = new PlayerId(1);
            var iidxId = new IidxId("1234-5678");
            var name = new PlayerName("PlayerName");
            var url = new Url("http://example.com");

            var player = new Player(playerId, iidxId, name, url);

            Assert.Equal(playerId, player.PlayerId);
            Assert.Equal(iidxId, player.IidxId);
            Assert.Equal(name, player.Name);
            Assert.Equal(url, player.Url);
        }
    }
}
