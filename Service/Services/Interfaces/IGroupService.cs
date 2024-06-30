
using Service.DTOs.Groups;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task CreateAsync(GroupCreateDto model);
        Task EditAsync(int? id, GroupEditDto model);
        Task DeleteAsync(int? id);
        Task<GroupDetailDto> GetByIdAsync(int id);
        Task<IEnumerable<GroupDto>> GetAllAsync();
        Task<IEnumerable<GroupDto>> SearchAsync(string name);
        Task<IEnumerable<GroupDto>> Sort(string sortName, bool isDescending);
        Task<bool> CheckIfExists(int? id);
        Task<List<GroupDto>> GetById(List<int>? id);
    }
}
