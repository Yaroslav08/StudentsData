using AutoMapper;
using StudentsData.Application.ViewModels;
using StudentsData.Application.ViewModels.Create;
using StudentsData.Application.ViewModels.Edit;
using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Application
{
    public class Converter : Profile
    {
        public Converter()
        {
            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<Group, GroupViewModel>().ForMember(d => d.Students, s => s.MapFrom(d => d.Students));
            CreateMap<Student, StudentViewModel>().ForMember(d => d.Group, s => s.MapFrom(d => d.Group));
            CreateMap<StudentCreateViewModel, Student>();
            CreateMap<StudentEditViewModel, Student>();
            CreateMap<TeacherCreateViewModel, Teacher>().ForMember(d => d.PasswordHash, s => s.MapFrom(d => d.Password));
        }
    }
}