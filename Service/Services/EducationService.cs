﻿using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Educations;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepo;
        private readonly IMapper _mapper;

        public EducationService(IMapper mapper,
                           IEducationRepository educationRepo)
        {
            _educationRepo = educationRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(EducationCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();

            await _educationRepo.CreateAsync(_mapper.Map<Education>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            var data = await _educationRepo.GetByIdAsync((int)id);
            await _educationRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, EducationEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _educationRepo.GetByIdAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _educationRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<EducationDto>> GetAllWithAsync()
        {
            var data = await _educationRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<EducationDto>>(data);
        }

        public async Task<EducationDto> GetByIdAsync(int? id)
        {
            return _mapper.Map<EducationDto>(await _educationRepo.GetByIdAsync((int)id));
        }

        public async Task<IEnumerable<EducationDto>> GetByName(string name)
        {
            if (name == null) throw new NotFoundException("Name is null");
            var data = _mapper.Map<IEnumerable<EducationDto>>(await _educationRepo.GetByName(name));

            return data;
        }

        public async Task<IEnumerable<EducationDto>> SortByName(string name)
        {
            if (name == null) throw new NotFoundException("Meesage is null");
            var data = _mapper.Map<IEnumerable<EducationDto>>(await _educationRepo.SortByName(name));

            return data;
        }
    }
}
