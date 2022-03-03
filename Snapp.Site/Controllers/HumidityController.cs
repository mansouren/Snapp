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
    public class HumidityController : Controller
    {
        private readonly IAdminService adminService;

        public HumidityController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var result =await adminService.GetHumidityTypes();
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
                adminService.AddHumidityType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Humidity humidity =await adminService.GetHumidityTypeById(id);
            MonthTypeViewModel viewModel = new MonthTypeViewModel
            {
                Name = humidity.Name,
                Start = humidity.Start,
                End = humidity.End,
                Percent = humidity.Percent
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id,MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.UpdateHumidityType(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteHumidityType(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
