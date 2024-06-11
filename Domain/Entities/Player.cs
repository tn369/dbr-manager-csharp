﻿using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Player
    {
        private readonly List<Player> _rivals = [];

        public IReadOnlyCollection<Player> Rivals => _rivals.AsReadOnly();

        public PlayerId? PlayerId { get; private set; }
        public IidxId IidxId { get; private set; }
        public PlayerName Name { get; private set; }
        public Profile Profile { get; private set; }

        public Player(IidxId iidxId, PlayerName name, Profile? profile)
        {
            IidxId = iidxId ?? throw new ArgumentNullException(nameof(iidxId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Profile = profile ?? new Profile(string.Empty);
        }
        private Player() { }

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
