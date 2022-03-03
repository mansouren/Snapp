using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class RoleController : Controller
    {
        private readonly IAdminService adminService;

        public RoleController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await adminService.GetRoles();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                adminService.AddRole(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Role role = await adminService.GetRoleById(id);
            RoleViewModel viewModel = new RoleViewModel
            {
                Name = role.Name,
                Title = role.Title
            };
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Edit(Guid id,RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               bool result= adminService.UpdateRole(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteRole(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
