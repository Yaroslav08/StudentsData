using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsData.Application.Interfaces;
using StudentsData.Application.ViewModels.Create;

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
            return LocalRedirect("~/");
        }
    }
}
