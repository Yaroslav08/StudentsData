using StudentsData.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        ITeacherRepository teacherRepos;

        IGroupRepository groupRepos;

        IStudentRepository studentRepos;

        public UnitOfWork(ITeacherRepository _teacherRepos, IGroupRepository _groupRepos, IStudentRepository _studentRepos)
        {
            teacherRepos = _teacherRepos;
            groupRepos = _groupRepos;
            studentRepos = _studentRepos;
        }

        public ITeacherRepository Teachers => teacherRepos;

        public IGroupRepository Groups => groupRepos;

        public IStudentRepository Students => studentRepos;
    }
}