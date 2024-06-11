using Domain.ValueObjects;

namespace Domain.Entities
{
    public class GameVersion
    {
        public GameVersionId GameVersionId { get; private set; }
        public GameVersionName Name { get; private set; }
        public GameVersion(GameVersionId gameVersionId, GameVersionName name)
        {
            GameVersionId = gameVersionId;
            Name = name;
        }
    }
}
