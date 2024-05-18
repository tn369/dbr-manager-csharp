using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Difficulty(DifficultyId difficultyId, DifficultyName name)
    {
        public DifficultyId DifficultyId { get; private set; } = difficultyId;
        public DifficultyName Name { get; private set; } = name;
    }

}
