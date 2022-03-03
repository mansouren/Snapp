using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class UserController : Controller
    {
        private readonly IAdminService adminService;
        PersianCalendar pc = new PersianCalendar();
        public UserController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await adminService.GetUsers();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var roles = await adminService.GetRoles();
            ViewBag.RoleId = new SelectList(roles, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!adminService.CheckUserName(viewModel.UserName))
                {
                    adminService.AddUser(viewModel);
                    ViewBag.IsSuccess = true;
                    return RedirectToAction(nameof(Index));
                }
            }

            var roles = await adminService.GetRoles();
            //if Creating User Was Unsuccessfull, we should load DropDownList Items again,on selected Item
            ViewBag.RoleId = new SelectList(roles, "Id", "Title", viewModel.RoleId);
            ViewBag.IsSuccess = false;
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            User user = await adminService.GetUserById(id);
            UserDetail userDetail = await adminService.GetUserDetail(id);

            UserEditViewModel viewModel = new UserEditViewModel
            {
                UserName = user.UserName,
                Isactive = user.Isactive,
                RoleId = user.RoleId,
                BirthDate = userDetail.BirthDate,
                FullName = userDetail.FullName
            };
            if (userDetail.BirthDate == null)
            {
                ViewBag.MyDate = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00")
                                 + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
            }
            else
            {
                ViewBag.MyDate = userDetail.BirthDate;
            }
            ViewBag.RoleId = new SelectList(await adminService.GetRoles(), "Id", "Title", user.RoleId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel viewModel, Guid id)
        {
            if (ModelState.IsValid)
            {
                if (!adminService.CheckUserNameForUpdate(viewModel.UserName, id))
                {
                    adminService.UpdateUser(viewModel, id);
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.MyDate = viewModel.BirthDate;
            ViewBag.RoleId = new SelectList(await adminService.GetRoles(), "Id", "Title", viewModel.RoleId);
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            adminService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditDriverProp(Guid id)
        {
            Driver driver = await adminService.GetDriver(id);
            DriverPropViewModel viewModel = new DriverPropViewModel
            {
                NationalCode = driver.NationalCode,
                Tel = driver.Tel,
                Address = driver.Address,
                AvatarName = driver.Avatar
            };
            ViewBag.IsError = false;
            ViewBag.IsSuccess = false;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDriverProp(DriverPropViewModel viewModel, Guid id)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = adminService.UpdateDriver(viewModel, id);
            }
            if (result)
            {
                ViewBag.IsSuccess = true;
                ViewBag.IsError = false;
            }
            else
            {
                ViewBag.IsSuccess = false;
                ViewBag.IsError = true;
            }

            var driver = await adminService.GetDriver(id);
            DriverPropViewModel propViewModel = new DriverPropViewModel
            {
                NationalCode = driver.NationalCode,
                Address = driver.Address,
                Tel = driver.Tel,
                AvatarName = driver.Avatar

            };
            return View(propViewModel);
        }

        public async Task<IActionResult> EditDriverCertificate(Guid id)
        {
            var driver = await adminService.GetDriver(id);
            DriverCertificateViewModel viewModel = new DriverCertificateViewModel
            {
                IsConfirmed = driver.IsConfirmed,
                CertificateImageName = driver.LicenceDocumentImg
            };
            ViewBag.IsSuccess = false;
            ViewBag.IsError = false;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDriverCertificate(DriverCertificateViewModel viewModel, Guid id)
        {
            Driver driver = await adminService.GetDriver(id);
            bool result = false;
            if (ModelState.IsValid)
            {
                result = adminService.UpdareDriverCertificate(viewModel, id);
            }
            if (result)
            {
                ViewBag.IsSuccess = true;
                ViewBag.IsError = false;
            }
            else
            {
                ViewBag.IsSuccess = false;
                ViewBag.IsError = true;
            }
            DriverCertificateViewModel model = new DriverCertificateViewModel
            {
                IsConfirmed = driver.IsConfirmed,
                CertificateImageName = driver.LicenceDocumentImg
            };
            return View(model);
        }

        public async Task<IActionResult> EditDriverCar(Guid id)
        {
            Driver driver = await adminService.GetDriver(id);
            DriverCarViewModel viewModel = new DriverCarViewModel
            {
                CarId = driver.CarId,
                ColorId = driver.ColorId,
                CarCode = driver.CarNumber
            };
            if (driver.CarId != null)
            {
                ViewBag.Car = new SelectList(await adminService.GetCars(), "Id", "Name", driver.CarId);

            }
            else
            {
                ViewBag.Car = new SelectList(await adminService.GetCars(), "Id", "Name");

            }
            if (driver.ColorId != null)
            {
                ViewBag.Color = new SelectList(await adminService.GetColors(), "Id", "Name", driver.ColorId);

            }
            else
            {
                ViewBag.Color = new SelectList(await adminService.GetColors(), "Id", "Name");

            }
            ViewBag.IsSuccess = false;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDriverCar(DriverCarViewModel viewModel, Guid id)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = adminService.UpdateDriverCar(viewModel, id);
            }
            if (result)
            {
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsSuccess = false;
            }

            ViewBag.Car = new SelectList(await adminService.GetCars(), "Id", "Name", viewModel.CarId);
            ViewBag.Color = new SelectList(await adminService.GetColors(), "Id", "Name", viewModel.ColorId);

            return View(viewModel);
        }
    }
}
