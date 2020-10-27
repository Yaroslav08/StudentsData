using StudentsData.Application.ViewModels;
using StudentsData.Application.ViewModels.Create;
using StudentsData.Application.ViewModels.Edit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Application.Interfaces
{
    public interface IStudentService
    {
        Task<string> CreateStudent(StudentCreateViewModel model);
        Task<string> EditStudent(StudentEditViewModel model);
        Task<string> RemoveStudent(int Id);
        Task<List<GroupViewModel>> GetGroupsForStudent();
        Task<StudentViewModel> GetStudentById(int Id);
        Task<StudentViewModel> GetStudentByIdWithGroup(int Id);
        Task<List<StudentViewModel>> GetAllStudents();
        Task<List<StudentViewModel>> SearchStudents(string name, int count, int skip);
    }
}