using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Domain.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<bool> IsExistTeacherAsync(string name);
    }
}