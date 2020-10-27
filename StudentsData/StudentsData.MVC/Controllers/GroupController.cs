using System;
using System.Collections.Generic;
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
    [Route("group")]
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger, IGroupService _groupService)
        {
            _logger = logger;
            groupService = _groupService;
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(GroupCreateViewModel model)
        {
            var res = await groupService.CreateGroup(model);
            if (res != "OK")
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/group/all");
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            var group = await groupService.GetGroupById(Id);
            if (group == null)
            {
                ViewBag.Error = "Group not found";
                return View("Error");
            }
            return View(new GroupEditViewModel
            {
                Id = group.Id,
                Name = group.Name
            });
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(GroupEditViewModel model)
        {
            var res = await groupService.EditGroup(model);
            if(res!="OK")
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/group/all");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(int Id)
        {
            var group = await groupService.GetGroupByIdWithStudents(Id);
            if (group == null)
            {
                ViewBag.Error = "Групу не знайдено";
                return View("Error");
            }
            return View(group);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllGroups(string name)
        {
            if (string.IsNullOrEmpty(name))
                return View(await groupService.GetAllGroups());
            return View(await groupService.SearchGroups(name));
        }

        [HttpGet("remove/{Id}")]
        public async Task<IActionResult> RemoveGroup(int Id)
        {
            var res = await groupService.RemoveGroup(Id);
            if (res != "OK")
            {
                ViewBag.Error = res;
                return View("Error");
            }
            return LocalRedirect("~/group/all");
        }

    }
}
