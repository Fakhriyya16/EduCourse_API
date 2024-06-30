
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EducationRepository : BaseRepository<Education>, IEducationRepository
    {
        public EducationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Education>> GetByName(string name)
        {
            var data = await _entities.Where(m => m.Name.Trim().Contains(name.Trim())).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Education>> SortByName(string message)
        {
            if (message == "asc")
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
    }
}
