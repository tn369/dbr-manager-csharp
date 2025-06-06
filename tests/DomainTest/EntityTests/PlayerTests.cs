using Domain.Entities;
using Domain.ValueObjects;
using Xunit;

namespace DomainTest.EntityTests
{
    public class PlayerTests
    {
        [Fact]
        public void AddRival_ShouldAddRivalToPlayer()
        {
            var iidxId1 = new IidxId("1234-5678");
            var name1 = new DJName("Player 1");
            var profile1 = new Profile("Player 1's profile");
            var player1 = new Player(iidxId1, name1, profile1);

            var iidxId2 = new IidxId("8765-4321");
            var name2 = new DJName("Player 2");
            var profile2 = new Profile("Player 2's profile");
            var player2 = new Player(iidxId2, name2, profile2);

            player1.AddRival(player2);

            Assert.Contains(player2, player1.Rivals);
        }

        [Fact]
        public void AddRival_ShouldNotAddDuplicateRival()
        {
            var iidxId1 = new IidxId("1234-5678");
            var name1 = new DJName("Player 1");
            var profile1 = new Profile("Player 1's profile");
            var player1 = new Player(iidxId1, name1, profile1);

            var iidxId2 = new IidxId("8765-4321");
            var name2 = new DJName("Player 2");
            var profile2 = new Profile("Player 2's profile");
            var player2 = new Player(iidxId2, name2, profile2);

            player1.AddRival(player2);
            player1.AddRival(player2);

            Assert.Single(player1.Rivals);
        }

        [Fact]
        public void RemoveRival_ShouldRemoveRivalFromPlayer()
        {
            var iidxId1 = new IidxId("1234-5678");
            var name1 = new DJName("Player 1");
            var profile1 = new Profile("Player 1's profile");
            var player1 = new Player(iidxId1, name1, profile1);

            var iidxId2 = new IidxId("8765-4321");
            var name2 = new DJName("Player 2");
            var profile2 = new Profile("Player 2's profile");
            var player2 = new Player(iidxId2, name2, profile2);

            player1.AddRival(player2);
            player1.RemoveRival(player2);

            Assert.DoesNotContain(player2, player1.Rivals);
        }

        [Fact]
        public void AddRival_ShouldNotAddSelfAsRival()
        {
            var iidxId1 = new IidxId("1234-5678");
            var name1 = new DJName("Player 1");
            var profile1 = new Profile("Player 1's profile");
            var player1 = new Player(iidxId1, name1, profile1);

            player1.AddRival(player1);

            Assert.Empty(player1.Rivals);
        }

        [Fact]
        public void Player_ProfileShouldDefaultToEmptyStringWhenNull()
        {
            var iidxId = new IidxId("1234-5678");
            var name = new DJName("Player");
            var player = new Player(iidxId, name, null);

            Assert.Equal(string.Empty, player.Profile.Value);
        }

        [Fact]
        public void Player_CannotBeCreated_WithNullParameters()
        {
            var iidxId = new IidxId("1234-5678");
            var name = new DJName("Player");
            var profile = new Profile("Player 1's profile");

            Assert.Throws<ArgumentNullException>(() => new Player(null, name, profile));
            Assert.Throws<ArgumentNullException>(() => new Player(iidxId, null, profile));
        }
    }
}
