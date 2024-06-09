using Domain.ValueObjects;

namespace Domain.Entities
{
    public class GameVersion(GameVersionId versionId, GameVersionName name)
    {
        public GameVersionId GameVersionId { get; private set; } = versionId;
        public GameVersionName Name { get; private set; } = name;
    }
}
