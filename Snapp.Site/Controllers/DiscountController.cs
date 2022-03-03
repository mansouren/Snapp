using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IAdminService adminService;

        public DiscountController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await adminService.GetDiscounts();
            return View(result);
        }

        public IActionResult Create()
        {
            ViewBag.MyStartDate = ShamsiDateTimeGenerator.GetShamsiDate();
            ViewBag.MyEndDate = ShamsiDateTimeGenerator.GetShamsiDate();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminDiscountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                adminService.AddDiscount(viewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MyStartDate = ShamsiDateTimeGenerator.GetShamsiDate();
            ViewBag.MyEndDate = ShamsiDateTimeGenerator.GetShamsiDate();
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await adminService.GetDiscountById(id);
            AdminDiscountViewModel viewModel = new AdminDiscountViewModel
            {
                Name = result.Name,
                Code = result.Code,
                Price = result.Price,
                Percent = result.Percent,
                Start = result.Start,
                End = result.End,
                Description = result.Description
            };
            if(result.Start == null) 
            {
                ViewBag.MyStartDate = ShamsiDateTimeGenerator.GetShamsiDate();
            }
            else
            {
                ViewBag.MyStartDate = result.Start;
            }

            if(result.End == null)
            {
                ViewBag.MyEndDate = ShamsiDateTimeGenerator.GetShamsiDate();
            }
            else
            {
                ViewBag.MyEndDate = result.End;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AdminDiscountViewModel viewModel)
        {
            var result = await adminService.GetDiscountById(id);
            if (ModelState.IsValid)
            {
                bool res = adminService.UpdateDiscount(viewModel, id);
                if (res)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.MyStartDate = viewModel.Start;
            ViewBag.MyEndDate = viewModel.End;
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteDiscount(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
