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
            var email = new Email("test@example.com");
            var name = new PlayerName("PlayerName");
            var url = new Url("http://example.com");
            var encryptPassword = new EncryptPassword("password");
            var salt = new Salt("salt");

            var player = new Player(playerId, iidxId, email, name, url, encryptPassword, salt);

            Assert.Equal(playerId, player.PlayerId);
            Assert.Equal(iidxId, player.IidxId);
            Assert.Equal(email, player.Email);
            Assert.Equal(name, player.Name);
            Assert.Equal(url, player.Url);
            Assert.Equal(encryptPassword, player.EncryptPassword);
            Assert.Equal(salt, player.Salt);
        }
    }
}
