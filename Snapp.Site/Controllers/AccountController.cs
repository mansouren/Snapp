using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await accountService.RegisterUser(viewModel);
                if (user != null)
                {
                    return RedirectToAction(nameof(Active));

                }
            }
            return View(viewModel);
        }

        public IActionResult Driver()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Driver(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await accountService.RegisterDriver(viewModel);
                if (user != null)
                {
                    return RedirectToAction(nameof(Active));

                }
            }
            return View(viewModel);
        }

        
        public IActionResult Active()
        {
            ViewBag.HasError = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Active(ActivateviewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await accountService.ActivateUser(viewModel);
                if (user != null)
                {
                    ViewBag.HasError = false;

                    #region Authentication
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };

                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(principal, properties);
                    return RedirectToAction("Dashboard", "Panel");

                    #endregion

                }
            }

            ViewBag.HasError = true;
            return View(viewModel);
        }
    }
}
