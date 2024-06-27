
using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Groups;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(GroupCreateDto model)
        {
            Group group = _mapper.Map<Group>(model);
            await _groupRepository.CreateAsync(group);
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Id is null");

            Group group = await _groupRepository.GetByIdAsync((int)id);

            if (group is null) throw new NotFoundException("Group was not found");

            await _groupRepository.DeleteAsync(group);
        }

        public async Task EditAsync(int? id, GroupEditDto model)
        {
            if (id is null) throw new ArgumentNullException();

            Group group = await _groupRepository.GetByIdAsync((int)id);

            if (group is null) throw new NotFoundException("Group was not found");

            _mapper.Map(model, group);

            await _groupRepository.EditAsync(group);
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(_groupRepository.FindAll(m=>m.StudentGroups));
        }

        public async Task<GroupDetailDto> GetByIdAsync(int id)
        {
            Group group = await _groupRepository.GetByIdAsync((int)id);

            if (group is null) throw new NotFoundException("Group was not found");

            return _mapper.Map<GroupDetailDto>(_groupRepository.FindBy(m => m.Id == id, m => m.StudentGroups));
        }

        public async Task<IEnumerable<GroupDto>> SearchAsync(string name)
        {
            var allGroups = _groupRepository.FindAll(m => m.StudentGroups);
            var result = new List<Group>();
            foreach (var group in allGroups)
            {
                if (group.Name.Contains(name.ToLower().Trim()))
                {
                    result.Add(group);
                }
            }

            return _mapper.Map<IEnumerable<GroupDto>>(result);
        }

        public async Task<IEnumerable<GroupDto>> Sort(string sortName, bool isDescending)
        {
            var allGroups = _groupRepository.FindAll(m => m.StudentGroups);

            if (sortName == "Name")
            {
                if (isDescending) return _mapper.Map<IEnumerable<GroupDto>>(allGroups.OrderByDescending(m => m.Name));
                else return _mapper.Map<IEnumerable<GroupDto>>(allGroups.OrderBy(m => m.Name));
            }
            else
            {
                if (isDescending) return _mapper.Map<IEnumerable<GroupDto>>(allGroups.OrderByDescending(m => m.Capacity));
                else return _mapper.Map<IEnumerable<GroupDto>>(allGroups.OrderBy(m => m.Capacity));
            }
        }
    }
}
