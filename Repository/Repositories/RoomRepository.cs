using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;


namespace Repository.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Room>> GetByName(string name)
        {
            var data = await _entities.Where(m => m.Name.Trim().Contains(name.Trim())).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Room>> SortByName(string name)
        {
            if (name == "asc")
            {
                var data = await _entities.OrderBy(m => m.Name).ToListAsync();
                return data;
            }
            else
            {
                var data = await _entities.OrderByDescending(m => m.Name).ToListAsync();

                return data;
            }
        }

        public async Task<IEnumerable<Room>> SortBySeatCount(string count)
        {
            if (count == "asc")
            {
                var data = await _entities.OrderBy(m => m.SeatCount).ToListAsync();
                return data;
            }
            else
            {
                var data = await _entities.OrderByDescending(m => m.SeatCount).ToListAsync();

                return data;
            }

        }
    }
}
