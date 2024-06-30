
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        Task<IEnumerable<Education>> GetByName(string name);

        Task<IEnumerable<Education>> SortByName(string name);
    }
}
