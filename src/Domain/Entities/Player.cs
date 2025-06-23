using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Player
    {
        private readonly List<Player> _rivals = [];

        public IReadOnlyCollection<Player> Rivals => _rivals.AsReadOnly();

        public PlayerId Id { get; private set; } = null!;
        public DJName DJName { get; private set; } = null!;
        public Profile Profile { get; private set; } = null!;

        public Player(DJName djName, Profile profile)
        {
            Id = new PlayerId(Guid.NewGuid().ToString());
            DJName = djName ?? throw new ArgumentNullException(nameof(djName));
            Profile = profile ?? throw new ArgumentNullException(nameof(profile));
        }
        private Player() { }

        public void ChangeDJName(DJName djName)
        {
            DJName = djName ?? throw new ArgumentNullException(nameof(djName));
        }

        public void ChangeProfile(Profile profile)
        {
            Profile = profile ?? throw new ArgumentNullException(nameof(profile));
        }

        public void AddRival(Player rival)
        {
            ArgumentNullException.ThrowIfNull(rival);

            if (!_rivals.Contains(rival) && rival != this)
            {
                _rivals.Add(rival);
            }
        }

        public void RemoveRival(Player rival)
        {
            ArgumentNullException.ThrowIfNull(rival);

            _rivals.Remove(rival);
        }
    }
}
