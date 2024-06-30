
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        Task<Teacher> GetByIdWithAsync(int? id);
        Task<IEnumerable<Teacher>> GetAllWithAsync();

        Task<IEnumerable<Teacher>> GetByNameOrSurname(string nameOrSurname);

        Task<IEnumerable<Teacher>> SortByName(string name);
        Task<IEnumerable<Teacher>> SortByAge(string age);
        Task<IEnumerable<Teacher>> SortBySalary(string salary);
    }
}
