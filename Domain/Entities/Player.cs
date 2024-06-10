using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Player(PlayerId playerId, IidxId iidxId, PlayerName name, Url url)
    {
        public PlayerId PlayerId { get; private set; } = playerId;
        public IidxId IidxId { get; private set; } = iidxId;
        public PlayerName Name { get; private set; } = name;
        public Url Url { get; private set; } = url;
    }
}
