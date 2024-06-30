using Service.DTOs.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ITeacherService
    {
        Task CreateAsync(TeacherCreateDto model);
        Task<IEnumerable<TeacherDto>> GetAllWithAsync();
        Task<TeacherDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(int id, TeacherEditDto model);
        Task<IEnumerable<TeacherDto>> GetByNameOrSurname(string nameOrSurname);
        Task<IEnumerable<TeacherDto>> SortByName(string name);
        Task<IEnumerable<TeacherDto>> SortByAge(string age);
        Task<IEnumerable<TeacherDto>> SortBySalary(string salary);
    }
}
