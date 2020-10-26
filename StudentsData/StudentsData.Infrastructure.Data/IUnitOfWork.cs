using StudentsData.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        ITeacherRepository Teachers { get; }
        IGroupRepository Groups { get; }
        IStudentRepository Students { get; }
    }
}