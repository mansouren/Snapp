using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class MonthTypeController : Controller
    {
        private readonly IAdminService adminService;

        public MonthTypeController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
           var result =await adminService.GetMonthTypes();
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
                adminService.AddMonthType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var monthType =await adminService.GetMonthTypeById(id);
            MonthTypeViewModel viewModel = new MonthTypeViewModel
            {
                Name = monthType.Name,
                Start = monthType.Start,
                End = monthType.End,
                Percent = monthType.Percent
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id,MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               bool result = adminService.UpdateMonthType(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteMonthType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
