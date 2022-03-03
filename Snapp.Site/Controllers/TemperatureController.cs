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
    public class TemperatureController : Controller
    {
        private readonly IAdminService adminService;

        public TemperatureController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await adminService.GetTemperatureTypes();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                adminService.AddTemperatureType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Temperature temperature = await adminService.GetTemperatureTypeById(id);
            MonthTypeViewModel viewModel = new MonthTypeViewModel
            {
                Name = temperature.Name,
                Start = temperature.Start,
                End = temperature.End,
                Percent = temperature.Percent
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.UpdateTemperatureType(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteTemperatureType(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
