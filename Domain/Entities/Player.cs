using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Player(PlayerId playerId, IidxId iidxId, Email email, PlayerName name, Url url, EncryptPassword encryptPassword, Salt salt)
    {
        public PlayerId PlayerId { get; private set; } = playerId;
        public IidxId IidxId { get; private set; } = iidxId;
        public Email Email { get; private set; } = email;
        public PlayerName Name { get; private set; } = name;
        public Url Url { get; private set; } = url;
        public EncryptPassword EncryptPassword { get; private set; } = encryptPassword;
        public Salt Salt { get; private set; } = salt;
    }

}
