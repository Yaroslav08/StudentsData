using StudentsData.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Application.Interfaces
{
    public interface IGroupService
    {
        Task<string> CreateGroup(GroupCreateViewModel model);
        Task<string> EditGroup(GroupEditViewModel model);
        Task<string> RemoveGroup(int Id);
        Task<GroupViewModel> GetGroupById(int Id);
        Task<GroupViewModel> GetGroupByIdWithStudents(int Id);
        Task<List<GroupViewModel>> GetAllGroups();
        Task<List<GroupViewModel>> SearchGroups(string name);
    }
}