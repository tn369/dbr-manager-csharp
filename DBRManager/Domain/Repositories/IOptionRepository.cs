using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IOptionRepository : IRepository<Option, OptionId> { }
}
