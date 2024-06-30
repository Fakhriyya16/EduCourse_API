using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Group>> GetByIdWithAsync(List<int>? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            List<Group> groups = new();
            foreach (var item in id)
            {
                if (!await _entities.AnyAsync(g => g.Id == item))
                {
                    throw new NullReferenceException(nameof(item));

                }
                else
                {
                    groups.Add(await _entities.Include(m=>m.StudentGroups).FirstOrDefaultAsync(m => m.Id == item));
                }
            }
            return groups;
        }
    }
}
