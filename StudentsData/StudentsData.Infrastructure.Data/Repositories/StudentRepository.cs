﻿using StudentsData.Domain.Interfaces;
using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Infrastructure.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

    }
}