using Microsoft.EntityFrameworkCore;
using StudentsData.Domain.Interfaces;
using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Infrastructure.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public async Task<Group> GetByGroupWithStudentsAsync(int Id)
        {
            return await db.Groups.AsNoTracking().Include(d => d.Students).SingleOrDefaultAsync(d => d.Id == Id);
        }

        public async Task<List<Group>> SearchGroupsAsync(string name)
        {
            return await db.Groups.AsNoTracking().Where(d => d.Name.Contains(name)).ToListAsync();
        }
    }
}