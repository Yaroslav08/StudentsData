using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Domain.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> GetByGroupWithStudentsAsync(int Id);
        Task<List<Group>> SearchGroupsAsync(string name);
    }
}