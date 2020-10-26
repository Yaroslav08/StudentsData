using Microsoft.EntityFrameworkCore;
using StudentsData.Domain.Interfaces;
using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Infrastructure.Data.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public async Task<bool> IsExistTeacherAsync(string name)
        {
            return await db.Teachers.AsNoTracking().FirstOrDefaultAsync(d => d.Username == name) != null ? true : false;
        }
    }
}