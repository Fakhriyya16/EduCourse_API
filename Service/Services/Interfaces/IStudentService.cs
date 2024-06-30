
using Service.DTOs.Students;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateAsync(StudentCreateDto model);
        Task EditAsync(int? id, StudentEditDto model);
        Task DeleteAsync(int? id);
        Task<StudentDetailDto> GetByIdAsync(int id);
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<IEnumerable<StudentDto>> SearchAsync(string nameOrSurname);
        Task<IEnumerable<StudentDto>> Filter(StudentFilterDto model);
    }
}
