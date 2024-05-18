using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Version(VersionId versionId, VersionName name)
    {
        public VersionId VersionId { get; private set; } = versionId;
        public VersionName Name { get; private set; } = name;
    }

}
