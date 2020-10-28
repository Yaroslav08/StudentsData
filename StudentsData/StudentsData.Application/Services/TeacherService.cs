using AutoMapper;
using StudentsData.Application.Interfaces;
using StudentsData.Application.ViewModels;
using StudentsData.Application.ViewModels.Create;
using StudentsData.Application.ViewModels.Edit;
using StudentsData.Domain.Models;
using StudentsData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public TeacherService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }


        public async Task<string> ConfirmTeacherAccount(TeacherConfirmViewModel model)
        {
            var teacher = await unitOfWork.Teachers.GetByWhereAsTrackingAsync(d => d.TokenConfirm == model.Token);
            if (teacher == null) return "Invalid token";
            if (teacher.IsConfirm) return "Teacher is confirmed";
            teacher.IsConfirm = true;
            teacher.DateConfirm = DateTime.Now;
            return await unitOfWork.Teachers.EditAsync(teacher);
        }

        public async Task<string> EditTeacher(TeacherEditViewModel model)
        {
            var teacher = await unitOfWork.Teachers.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (teacher == null) return "Teacher not found";
            if (teacher.Username != model.Username)
            {
                if (await unitOfWork.Teachers.IsExistTeacherAsync(model.Username))
                    return "Нікнейм зайнятий";
            }
            teacher.Fullname = model.Fullname;
            teacher.Avatar = model.Avatar;
            teacher.Username = model.Username;
            return await unitOfWork.Teachers.EditAsync(teacher);
        }

        public async Task<TeacherViewModel> GetMe(int id)
        {
            return mapper.Map<TeacherViewModel>(await unitOfWork.Teachers.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<Teacher> LoginTeacher(string login, string password)
        {
            var teacher = await unitOfWork.Teachers.GetByWhereAsync(d => d.Login == login);
            if (teacher == null) return null;
            if (teacher.PasswordHash != password) return null;
            return teacher;
        }

        public async Task<string> RegisterTeacher(TeacherCreateViewModel model)
        {
            var teacher = mapper.Map<Teacher>(model);
            return await unitOfWork.Teachers.CreateAsync(teacher);
        }
    }
}