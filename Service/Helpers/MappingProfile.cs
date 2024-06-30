using AutoMapper;
using Domain.Entities;
using Service.DTOs.Educations;
using Service.DTOs.Groups;
using Service.DTOs.Rooms;
using Service.DTOs.Students;
using Service.DTOs.Teachers;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDto>().ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentGroups.Select(m=>m.Student.Name + " " + m.Student.Surname).ToList()));
            CreateMap<Group, GroupDetailDto>().ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentGroups.Count));
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>();

            CreateMap<Student, StudentDto>().ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.StudentGroups.Select(m=>m.Group.Name).ToList()));
            CreateMap<Student, StudentDetailDto>().ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.StudentGroups.Select(m => m.Group.Name).ToList()));
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentEditDto, Student>();

            CreateMap<Education, EducationDto>();
            CreateMap<EducationCreateDto, Education>();
            CreateMap<EducationEditDto, Education>();


            CreateMap<Room, RoomDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomEditDto, Room>();

            CreateMap<Teacher, TeacherDto>().ForMember(dest => dest.Groups, opt => opt.MapFrom(src =>
                src.GroupTeachers.Select(gs => gs.Group))); ;
            CreateMap<TeacherCreateDto, Teacher>();
            CreateMap<TeacherEditDto, Teacher>();
        }
    }
}
