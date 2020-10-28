using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsData.Application.Interfaces;
using StudentsData.Application.ViewModels.Create;
using StudentsData.Application.ViewModels.Edit;

namespace StudentsData.MVC.Controllers
{
    [Route("Teacher")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ILogger<TeacherController> logger, ITeacherService _teacherService)
        {
            _logger = logger;
            teacherService = _teacherService;
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TeacherCreateViewModel model)
        {
            var res = await teacherService.RegisterTeacher(model);
            if (res != "OK")
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/Teacher/Confirm");
        }

        [HttpGet("Confirm")]
        public IActionResult ConfirmTeacherAccount()
        {
            return View();
        }

        [HttpPost("Confirm")]
        public async Task<IActionResult> ConfirmTeacherAccount(TeacherConfirmViewModel model)
        {
            var res = await teacherService.ConfirmTeacherAccount(model);
            if (res != "OK") 
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/login");
        }

        [HttpGet("Me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var teacher = await teacherService.GetMe(Convert.ToInt32(User.Claims.First(d => d.Type == "Id").Value));
            if (teacher == null)
            {
                return LocalRedirect("~/logout");
            }
            return View(teacher);
        }
    }
}
