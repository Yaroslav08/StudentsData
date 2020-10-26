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
    [Route("teacher")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ILogger<TeacherController> logger, ITeacherService _teacherService)
        {
            _logger = logger;
            teacherService = _teacherService;
        }

        [HttpGet("create")]
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeacher(TeacherCreateViewModel model)
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
