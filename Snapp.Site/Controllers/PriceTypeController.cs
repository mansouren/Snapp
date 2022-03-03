using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class PriceTypeController : Controller
    {
        private readonly IAdminService adminService;

        public PriceTypeController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var result =await adminService.GetPriceTypes();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PriceTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                adminService.AddPriceType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var priceType =await adminService.GetPriceTypeById(id);
            PriceTypeViewModel viewModel = new PriceTypeViewModel
            {
                Name = priceType.Name,
                Start = priceType.Start,
                End = priceType.End,
                Price = priceType.Price
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id,PriceTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result= adminService.UpdatePriceType(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));

                }
            }
          
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeletePriceType(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
