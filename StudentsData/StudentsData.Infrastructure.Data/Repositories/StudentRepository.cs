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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public async Task<Student> GetStudentWithGroupById(int Id)
        {
            return await db.Students.AsNoTracking().Include(d => d.Group).SingleOrDefaultAsync(d => d.Id == Id);
        }

        public async Task<List<Student>> SearchStudents(string name, int count, int skip)
        {
            return await db.Students.AsNoTracking()
                .Where(d => d.Lastname.Contains(name) || d.Firstname.Contains(name))
                .Skip(skip).Take(count)
                .ToListAsync();
        }
    }
}