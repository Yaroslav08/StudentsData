using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsData.Application.Interfaces;
using StudentsData.Application.ViewModels;
using StudentsData.Domain.Models;

namespace StudentsData.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITeacherService _teacherService)
        {
            _logger = logger;
            teacherService = _teacherService;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var res = await teacherService.LoginTeacher(model.Login, model.Password);
            if (res == null)
            {
                ModelState.AddModelError("", "Логін чи пароль невірні");
                return View(model);
            }
            await AuthenticateAsync(res);
            return LocalRedirect("~/");
        }



        private async Task AuthenticateAsync(Teacher teacher)
        {
            var claims = new List<Claim>
            {
                new Claim("Name", teacher.Fullname),
                new Claim("Id", teacher.Id.ToString())
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("~/login");
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
