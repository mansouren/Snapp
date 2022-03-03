using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class RateTypeController : Controller
    {
        private readonly IAdminService adminService;

        public RateTypeController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var rateTypes =await adminService.GetRateTypes();
            return View(rateTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RateTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                adminService.AddRateType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var ratetype =await adminService.GetRateTypeById(id);
            RateTypeViewModel viewModel = new RateTypeViewModel
            {
                Name = ratetype.Name,
                Ok = ratetype.Ok,
                ViewOrder = ratetype.ViewOrder

            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id,RateTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               var result = adminService.UpdateRateType(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));

                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteRateType(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
