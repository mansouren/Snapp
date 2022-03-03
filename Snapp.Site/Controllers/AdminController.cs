using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Snapp.Core.ViewModels;

namespace Snapp.Site.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private PersianCalendar pc = new PersianCalendar();

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SiteSettings()
        {
            var result = await adminService.GetSettings();
            SiteSettingsViewModel viewModel = new SiteSettingsViewModel
            {
                Desc = result.Desc,
                Fax = result.Fax,
                Tel = result.Tel,
                Name = result.Name
            };

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SiteSettings(SiteSettingsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.UpdateSiteSettings(viewModel);

                ViewBag.IsSuccess = result;

            }
            return View(viewModel);
        }

        public async Task<IActionResult> PriceSettings()
        {
            var result = await adminService.GetSettings();
            PriceSettingViewModel viewModel = new PriceSettingViewModel
            {
                ConsiderWeatherForPrice = result.ConsiderWeatherForPrice,
                ConsiderDistanceForPrice = result.ConsiderDistanceForPrice
            };

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PriceSettings(PriceSettingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.UpdatePriceSettings(viewModel);

                ViewBag.IsSuccess = result;

            }
            return View(viewModel);
        }

        public async Task<IActionResult> AboutSettings()
        {
            var settings = await adminService.GetSettings();
            AboutSettingViewModel viewModel = new AboutSettingViewModel
            {
                About = settings.About
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AboutSettings(AboutSettingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.UpdateAboutSettings(viewModel);
                ViewBag.IsSuccess = result;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> TermsSettings()
        {
            var settings = await adminService.GetSettings();
            TermsSettingViewModel viewModel = new TermsSettingViewModel
            {
                Terms = settings.Terms
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult TermsSettings(TermsSettingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.UpdateTermsSettings(viewModel);
                ViewBag.IsSuccess = result;
            }

            return View(viewModel);
        }

        public IActionResult WeeklyFactors()
        {
            //Getting DateTime.Now() in string and shamsi format and then divid that to 3 parts 0000/00/00
            string strToday = ShamsiDateTimeGenerator.GetShamsiDate();
            int year = Convert.ToInt32(strToday.Substring(0, 4));   //0000
            int month = Convert.ToInt32(strToday.Substring(5, 2)); //00
            int day = Convert.ToInt32(strToday.Substring(8, 2));  //00
            //Define list Of charts
            var charts = new List<ChartViewModel>();
            //WeekDays for loop
            for (int i = 0; i <= 6; i++)
            {
                DateTime date = pc.ToDateTime(year, month, day, 0, 0, 0, 0); //Converting strToday's Parts that has been divided in previuos step to PersianCalander DateTime Formar
                if (i == 0)
                {
                    date = date.AddDays(i); // we get today in miladi format
                }
                else
                {
                    int dayCounter = -i; //Makes i Negative
                    date = date.AddDays(dayCounter); //forexample if i=-2 , we can get 2 days ago datetime in miladi format
                }

                //Converting back to date to string format
                string strShamsiDate = pc.GetYear(date).ToString("0000") + "/" +
                                       pc.GetMonth(date).ToString("00") + "/" +
                                       pc.GetDayOfMonth(date).ToString("00");
                ChartViewModel chart = new ChartViewModel
                {
                    Label = strShamsiDate,
                    Value = adminService.WeeklyFactorChart(strShamsiDate),
                    Color = ColorGenerator.GetColorCode()
                };
                charts.Add(chart);
            }
            return View(charts);
        }

        public IActionResult MonthlyFactor()
        {
            var charts = new List<ChartViewModel>();
            for (int i = 1; i <= 12; i++)
            {
                string strmonth = i.ToString("00");
                ChartViewModel chart = new ChartViewModel
                {
                    Color = ColorGenerator.GetColorCode(),
                    Label = MonthConvertor.FarsiMonth(i),
                    Value = adminService.MonthlyFactorChart(strmonth)
                };
                charts.Add(chart);
            }
            return View(charts);
        }

        public IActionResult WeeklyRegisters()
        {
            string strToday = ShamsiDateTimeGenerator.GetShamsiDate();
            int year =Convert.ToInt32(strToday.Substring(0, 4));
            int month = Convert.ToInt32(strToday.Substring(5, 2));
            int day = Convert.ToInt32(strToday.Substring(8, 2));
            var charts = new List<ChartViewModel>();

            for (int i = 0; i <= 6; i++)
            {
                DateTime date = pc.ToDateTime(year,month,day,0,0,0,0);
                if(i == 0)
                {
                    date = date.AddDays(i);
                }
                else
                {
                    int dayCounter = -i;
                    date = date.AddDays(dayCounter);
                }

                string dateInShamsiFormat = pc.GetYear(date).ToString("0000") + "/" +
                                            pc.GetMonth(date).ToString("00") + "/" +
                                            pc.GetDayOfMonth(date).ToString("00");

                ChartViewModel chart = new ChartViewModel
                {
                    Color = ColorGenerator.GetColorCode(),
                    Label = dateInShamsiFormat,
                    Value = adminService.WeeklyUserRegisters(dateInShamsiFormat)
                };
                charts.Add(chart);
            }
            return View(charts);
        }

        public IActionResult MonthlyRegisters()
        {
            var charts = new List<ChartViewModel>();
            for (int i = 1; i <= 12; i++)
            {
                string strmonth = i.ToString("00");
                ChartViewModel chart = new ChartViewModel
                {
                    Color = ColorGenerator.GetColorCode(),
                    Label = MonthConvertor.FarsiMonth(i),
                    Value = adminService.MonthlyRegisters(strmonth)
                };
                charts.Add(chart);
            }

            return View(charts);
        }
    }
}
