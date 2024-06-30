using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Teachers;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;

        public TeacherService(IMapper mapper,
                           IGroupRepository groupRepo,
                           ITeacherRepository teacherRepo)
        {
            _mapper = mapper;
            _groupRepo = groupRepo;
            _teacherRepo = teacherRepo;
        }

        public async Task CreateAsync(TeacherCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();

            await _teacherRepo.CreateAsync(_mapper.Map<Teacher>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _teacherRepo.GetByIdAsync(id);
            await _teacherRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, TeacherEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _teacherRepo.GetByIdWithAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _teacherRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<TeacherDto>> GetAllWithAsync()
        {
            var teachers = await _teacherRepo.GetAllWithAsync();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }

        public async Task<TeacherDto> GetByIdAsync(int id)
        {
            return _mapper.Map<TeacherDto>(await _teacherRepo.GetByIdWithAsync(id));
        }

        public async Task<IEnumerable<TeacherDto>> GetByNameOrSurname(string nameOrSurname)
        {
            if (nameOrSurname == null) throw new NotFoundException("Name or surname is null");
            var data = _mapper.Map<IEnumerable<TeacherDto>>(await _teacherRepo.GetByNameOrSurname(nameOrSurname));

            return data;
        }

        public async Task<IEnumerable<TeacherDto>> SortByAge(string age)
        {
            if (age == null) throw new NotFoundException("Message is null");
            var data = _mapper.Map<IEnumerable<TeacherDto>>(await _teacherRepo.SortByAge(age));

            return data;
        }

        public async Task<IEnumerable<TeacherDto>> SortByName(string name)
        {
            if (name == null) throw new NotFoundException("Message is null");
            var data = _mapper.Map<IEnumerable<TeacherDto>>(await _teacherRepo.SortByName(name));

            return data;
        }

        public async Task<IEnumerable<TeacherDto>> SortBySalary(string salary)
        {
            if (salary == null) throw new NotFoundException("Message is null");
            var data = _mapper.Map<IEnumerable<TeacherDto>>(await _teacherRepo.SortBySalary(salary));

            return data;
        }
    }
}

