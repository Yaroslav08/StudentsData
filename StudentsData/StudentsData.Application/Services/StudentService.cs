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
    public class StudentService : IStudentService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public StudentService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<string> CreateStudent(StudentCreateViewModel model)
        {
            return await unitOfWork.Students.CreateAsync(mapper.Map<Student>(model));
        }

        public async Task<string> EditStudent(StudentEditViewModel model)
        {
            return await unitOfWork.Students.EditAsync(mapper.Map<Student>(model));
        }

        public async Task<List<StudentViewModel>> GetAllStudents()
        {
            return mapper.Map<List<StudentViewModel>>(await unitOfWork.Students.GetAllAsync());
        }

        public async Task<List<GroupViewModel>> GetGroupsForStudent()
        {
            return mapper.Map<List<GroupViewModel>>(await unitOfWork.Groups.GetAllAsync());
        }

        public async Task<StudentViewModel> GetStudentById(int Id)
        {
            return mapper.Map<StudentViewModel>(await unitOfWork.Students.GetByWhereAsync(d => d.Id == Id));
        }

        public async Task<StudentViewModel> GetStudentByIdWithGroup(int Id)
        {
            return mapper.Map<StudentViewModel>(await unitOfWork.Students.GetStudentWithGroupById(Id));
        }

        public async Task<string> RemoveStudent(int Id)
        {
            var student = await unitOfWork.Students.GetByWhereAsTrackingAsync(d => d.Id == Id);
            if (student == null)
                return "Error";
            return await unitOfWork.Students.RemoveAsync(student);
        }

        public async Task<List<StudentViewModel>> SearchStudents(string name, int count, int skip)
        {
            return mapper.Map<List<StudentViewModel>>(await unitOfWork.Students.SearchStudents(name, count, skip));
        }
    }
}