
using AutoMapper;
using Domain.Entities;
using Service.DTOs.Groups;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDto>().ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentGroups.Select(m=>m.Student.Name + " " + m.Student.Surname).ToList()));
            CreateMap<Group, GroupDetailDto>().ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentGroups.Select(m => m.Student.Name + " " + m.Student.Surname).ToList()));
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>();
        }
    }
}
