using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Rooms;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;

        private readonly IMapper _mapper;

        public RoomService(IMapper mapper,
                           IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(RoomCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();

            await _roomRepo.CreateAsync(_mapper.Map<Room>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            var data = await _roomRepo.GetByIdAsync((int)id);
            await _roomRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, RoomEditDto model)
        {
            if (model == null) throw new ArgumentNullException();

            var data = await _roomRepo.GetByIdAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _roomRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<RoomDto>> GetAllWithAsync()
        {
            var data = await _roomRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(data);
        }

        public async Task<RoomDto> GetByIdAsync(int? id)
        {
            return _mapper.Map<RoomDto>(await _roomRepo.GetByIdAsync((int)id));
        }

        public async Task<IEnumerable<RoomDto>> GetByName(string name)
        {
            if (name == null) throw new NotFoundException("Name is null");
            var data = _mapper.Map<IEnumerable<RoomDto>>(await _roomRepo.GetByName(name));

            return data;
        }

        public async Task<IEnumerable<RoomDto>> SortByName(string name)
        {
            if (name == null) throw new NotFoundException("Meesage is null");
            var data = _mapper.Map<IEnumerable<RoomDto>>(await _roomRepo.SortByName(name));

            return data;
        }

        public async Task<IEnumerable<RoomDto>> SortBySeatCount(string count)
        {
            if (count == null) throw new NotFoundException("Message is null");
            var data = _mapper.Map<IEnumerable<RoomDto>>(await _roomRepo.SortBySeatCount(count));

            return data;
        }
    }
}

