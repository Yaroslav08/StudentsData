using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsData.Application.Interfaces;
using StudentsData.Application.ViewModels.Create;
using StudentsData.Application.ViewModels.Edit;

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

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Groups = await studentService.GetGroupsForStudent();
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(StudentCreateViewModel model)
        {
            var res = await studentService.CreateStudent(model);
            if (res != "OK")
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/student/all");
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            var student = await studentService.GetStudentById(Id);
            if (student == null)
            {
                ViewBag.Error = "Student not found";
                return View("Error");
            }
            ViewBag.Groups = await studentService.GetGroupsForStudent();
            return View(new StudentEditViewModel
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Middlename = student.Middlename,
                Lastname = student.Lastname,
                Address = student.Address,
                EmailAddress = student.EmailAddress,
                MobilePhone = student.MobilePhone,
                Passport = student.Passport,
                Photo = student.Photo
            });
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(StudentEditViewModel model)
        {
            var res = await studentService.EditStudent(model);
            if (res != "OK")
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/student/all");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return View(await studentService.GetAllStudents());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(int Id)
        {
            var student = await studentService.GetStudentById(Id);
            if (student == null)
            {
                ViewBag.Error = "Студента не знайдено";
                return View("Error");
            }
            return View(student);
        }

        [HttpGet("remove/{Id}")]
        public async Task<IActionResult> Remove(int Id)
        {
            var res = await studentService.RemoveStudent(Id);
            if (res != "OK")
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/student/all");
        }
    }
}
