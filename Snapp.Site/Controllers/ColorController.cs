using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.ViewModels.Admin;

namespace Snapp.Site.Controllers
{
    public class ColorController : Controller
    {
        private readonly IAdminService adminService;

        public ColorController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await adminService.GetColors();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminColorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                adminService.AddColor(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var color = await adminService.GetColorById(id);
            AdminColorViewModel viewModel = new AdminColorViewModel
            {
                Name = color.Name,
                Code = color.Code
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, AdminColorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               var result = adminService.UpdateColor(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteColor(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
