using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetStudentWithGroupById(int Id);
        Task<List<Student>> SearchStudents(string name, int count, int skip);
    }
}