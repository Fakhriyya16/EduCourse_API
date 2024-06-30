using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Students;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository,IMapper mapper, 
                              IGroupRepository groupRepo)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _groupRepo = groupRepo;
        }
        public async Task CreateAsync(StudentCreateDto model)
        {
            var existGroup = await _groupRepo.GetByIdWithAsync(model.GroupId) ?? throw new NotFoundException("Groups are not found");
            if (model == null) throw new ArgumentNullException();

            foreach (var item in existGroup)
            {
                if (item.Capacity < item.StudentGroups.Select(m=>m.Student).Count())
                {
                    throw new NotFoundException($"Group is full");
                }
                StudentGroups newRow = new() { GroupId = item.Id, Student = _mapper.Map<Student>(model)};
            }
            await _studentRepository.CreateAsync(_mapper.Map<Student>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var student = await _studentRepository.GetByIdAsync((int)id);

            if (student is null) throw new NotFoundException("Student was not found");

            await _studentRepository.DeleteAsync(student);
        }

        public async Task EditAsync(int? id, StudentEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
           
            var data = await _studentRepository.GetByIdAsync((int)id) ?? throw new ArgumentNullException();
            
            var editedData = _mapper.Map(model, data);
            
            await _studentRepository.EditAsync(editedData);
        }

        public async Task<IEnumerable<StudentDto>> Filter(StudentFilterDto model)
        {
            if (model is null) throw new ArgumentNullException();

            return _mapper.Map<IEnumerable<StudentDto>>(
                _studentRepository.FindBy(m => m.Name == model.Name && m.Surname == model.Surname && m.Age > model.MinAge && m.Age < model.MaxAge,m=>m.StudentGroups));
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(_studentRepository.FindAll(m=>m.StudentGroups));
        }

        public async Task<StudentDetailDto> GetByIdAsync(int id)
        {
            return _mapper.Map<StudentDetailDto>(_studentRepository.FindBy(m=>m.Id == id,m=>m.StudentGroups).FirstOrDefault());
        }

        public async Task<IEnumerable<StudentDto>> SearchAsync(string nameOrSurname)
        {
            if (string.IsNullOrEmpty(nameOrSurname)) throw new ArgumentNullException();

            return _mapper.Map<IEnumerable<StudentDto>>(_studentRepository.FindBy(m => m.Name == nameOrSurname || m.Surname == nameOrSurname, m => m.StudentGroups));
        }
    }
}
