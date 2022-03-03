using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class CarController : Controller
    {
        private readonly IAdminService adminService;

        public CarController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await adminService.GetCars();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                adminService.AddCar(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await adminService.GetCarById(id);
            CarViewModel viewModel = new CarViewModel
            {
                Name = result.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, CarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.UpdateCar(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));

                }
            }

            return View(viewModel);
        }


        public IActionResult Delete(Guid id)
        {
            adminService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ImportFile()
        {
            return View();
        }

        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file != null)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int i = 2; i <= rowCount; i++)
                        {
                            CarViewModel viewModel = new CarViewModel
                            {
                                Name = worksheet.Cells[i, 1].Value.ToString().Trim()
                            };
                            adminService.AddCar(viewModel);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(ImportFile));
        }
    }
}
