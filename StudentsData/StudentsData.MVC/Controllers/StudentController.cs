using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsData.Application.Interfaces;

namespace StudentsData.MVC.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, IStudentService _studentService)
        {
            _logger = logger;
            studentService = _studentService;
        }



    }
}
