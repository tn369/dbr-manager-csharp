using Domain.ValueObjects;

namespace Domain.Entities
{
    public class GameVersion
    {
        public GameVersionId GameVersionId { get; private set; } = null!;
        public GameVersionName Name { get; private set; } = null!;
        public GameVersion(GameVersionId gameVersionId, GameVersionName name)
        {
            GameVersionId = gameVersionId ?? throw new ArgumentNullException(nameof(gameVersionId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        private GameVersion() { }
    }
}
