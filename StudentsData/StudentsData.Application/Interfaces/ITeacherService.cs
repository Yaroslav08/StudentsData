using StudentsData.Application.ViewModels;
using StudentsData.Application.ViewModels.Create;
using StudentsData.Application.ViewModels.Edit;
using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Application.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> LoginTeacher(string login, string password);
        Task<string> RegisterTeacher(TeacherCreateViewModel model);
        Task<TeacherViewModel> GetMe(int id);
        Task<string> EditTeacher(TeacherEditViewModel model);
        Task<string> ConfirmTeacherAccount(TeacherConfirmViewModel model);
    }
}