using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels;
using Snapp.Core.ViewModels.Payment;
using Snapp.Core.ViewModels.Profile;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        private readonly IPanelService panelService;

        public PanelController(IPanelService panelService)
        {
            this.panelService = panelService;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> ConfirmRequest(double id) //d in km is id parameter
        {
            var price = panelService.GetPrice(id);

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org");
            var response = await client.GetAsync($"/data/2.5/weather?lat=38&lon=52&units=metric&appid=758fda28b7da84d1e8d6060c04e102c6");

            var result = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(result);// نوع متغیر هایی که به وسیله این نوع داده(dynamic) ای مشخص می شوند، در زمان اجرا تعیین خواهد شد (نه در زمان کامپایل)

            WeatherViewModel viewModel = new WeatherViewModel
            {
                Temp = Math.Round((float)obj.main.temp - 32 * (5 / 9), 2),//Get Temp in °C 
                humidity = Math.Round((float)obj.main.humidity)
            };

            float tempPercent = panelService.GetTempPercent(viewModel.Temp);
            float humPercent = panelService.GetHumidityPercent(viewModel.humidity);

            price = Convert.ToInt64(price + (price * tempPercent));
            price = Convert.ToInt64(price + (price * humPercent));

            PriceConfirmViewModel priceConfirm = new PriceConfirmViewModel
            {
                Price = price
            };

            return View(priceConfirm);
        }

        public async Task<IActionResult> EditUserDetailProfile()
        {
            var userdetail = await panelService.GetUserDetail(User.Identity.Name);
            UserDetailProfileViewModel viewModel = new UserDetailProfileViewModel
            {
                FullName = userdetail.FullName,
                BirthDate = userdetail.BirthDate
            };
            ViewBag.IsSuccess = false;
            ViewBag.MyDate = ShamsiDateTimeGenerator.GetShamsiDate();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserDetailProfile(UserDetailProfileViewModel viewModel)
        {
            var userdetail = await panelService.GetUserDetail(User.Identity.Name);

            if (ModelState.IsValid)
            {
                bool result = panelService.UpdateUserDetailProfile(userdetail.UserId, viewModel);
                ViewBag.IsSuccess = result;
                ViewBag.MyDate = viewModel.BirthDate;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> ResultPayment(Guid id)
        {
            var factor = await panelService.GetFactorById(id);
            return View(factor);
        }

        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost] //ZarinPal
        public async Task<IActionResult> Payment(FactorViewModel viewModel)
        {
            UserDetail userdetail = await panelService.GetUserDetail(User.Identity.Name);
            var ordernumber = CodeGenerators.GetOrderCode();//8 digit number
            //Check If User has an open factor from past
            bool checkFactor = panelService.UpdateFactor(userdetail.UserId, ordernumber, viewModel.Wallet);
            if (checkFactor == false) //If User dosent have an open factor
            {
                Factor factor = new Factor()
                {
                    BankName = null,
                    Date = null,
                    Time = null,
                    OrderNumber = ordernumber,
                    Price = Convert.ToInt32(viewModel.Wallet),
                    Description = null,
                    RefNumber = null,
                    TraceNumber = null,
                    UserId = userdetail.UserId,
                    Id = CodeGenerators.GetId()
                };
                panelService.AddFactor(factor);
            }
            Guid factorId = panelService.GetFactor(ordernumber);
            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(viewModel.Wallet));
            var res = payment.PaymentRequest("تراکنش جدید", "https://localhost:44392/Panel/PaymentCallBack/" + factorId);
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            return Redirect("/Panel/ResultPayment/" + factorId);
        }

        public async Task<IActionResult> PaymentCallBack(Guid id)
        {
            Factor factor = await panelService.GetFactorById(id);
            string authority = HttpContext.Request.Query["Authority"];
            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(factor.Price));
            var result = payment.Verification(authority).Result;
            if (result.Status == 100)
            {
                panelService.UpdatePayment(id, ShamsiDateTimeGenerator.GetShamsiDate()
                                           , ShamsiDateTimeGenerator.GetTimeInFormat()
                                           , "افزایش اعتبار زرین پال", "زرین پال"
                                           , result.RefId.ToString(), result.RefId.ToString());
            }
            return Redirect("/Panel/ResultPayment/" + id);
        }

        //Sadad Melli Bank
        //[HttpPost]
        //public async Task<IActionResult> Payment(FactorViewModel viewModel)
        //{
        //    UserDetail userdetail = await panelService.GetUserDetail(User.Identity.Name);
        //    var ordernumber = CodeGenerators.GetOrderCode();//8 digit number
        //    //Check If User has an open factor from past
        //    bool checkFactor = panelService.UpdateFactor(userdetail.UserId, ordernumber, viewModel.Wallet);
        //    if (checkFactor == false) //If User dosnet have an open factor
        //    {
        //        Factor factor = new Factor()
        //        {
        //            BankName = null,
        //            Date = null,
        //            Time = null,
        //            OrderNumber = ordernumber,
        //            Price = Convert.ToInt32(viewModel.Wallet),
        //            Description = null,
        //            RefNumber = null,
        //            TraceNumber = null,
        //            UserId = userdetail.UserId,
        //            Id = CodeGenerators.GetId()
        //        };
        //        panelService.AddFactor(factor);
        //    }
        //    //if User has an open factor we should send paymentRequest to bankService
        //    //You should get these items from bank service
        //    string merchantId = "";//شماره پذيرنده 
        //    string terminalId = "";//شماره ترمینال
        //    string merchantKey = "";//کلید تراکنش 

        //    //these codes are from sample code in bank guide website with document
        //    var dataBytes = Encoding.UTF8.GetBytes(string.Format("{0};{1};{2}", terminalId, ordernumber, viewModel.Wallet));

        //    var symmetric = SymmetricAlgorithm.Create("TripleDes");
        //    symmetric.Mode = CipherMode.ECB;
        //    symmetric.Padding = PaddingMode.PKCS7;

        //    var encryptor = symmetric.CreateEncryptor(Convert.FromBase64String(merchantKey), new byte[8]);

        //    string signData = Convert.ToBase64String(encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length));

        //    //PaymentRequest method's parameters 
        //    var myData = new
        //    {
        //        MerchantId = merchantId,
        //        TerminalId = terminalId,
        //        Amount = viewModel.Wallet,
        //        OrderId = ordernumber,
        //        LocalDateTime = DateTime.Now,
        //        ReturnUrl = "https://localhost:44392/Panel/CallBack",
        //        SignData = signData
        //    };
        //    Guid factorId = panelService.GetFactor(ordernumber);

        //    //Getting Result from PaymentRequest method
        //    var res = CallApi<PayResultData>("https://sadad.shaparak.ir/api/v0/Request/PaymentRequest", myData).Result;

        //    if (res.ResCode == 0)
        //    {
        //        //Redirecting client to bank payment gateway page with token that has got from previous step
        //        return Redirect($"https://sadad.shaparak.ir/Purchase/Index?token={res.Token}");
        //    }
        //    else
        //    {
        //        return Redirect("/Panel/ResultPayment/" + factorId);

        //    }

        //}

        [HttpPost]
        public IActionResult CallBack(CallbackRequestPayment callback)
        {
            //You should get these items from bank service
            string merchantKey = "";

            Guid factorId = panelService.GetFactor(callback.OrderId.ToString());

            var byteData = Encoding.UTF8.GetBytes(callback.Token);
            var myAlgorithym = SymmetricAlgorithm.Create("TripleDes");
            myAlgorithym.Mode = CipherMode.ECB;
            myAlgorithym.Padding = PaddingMode.PKCS7;
            var myEnc = myAlgorithym.CreateEncryptor(Convert.FromBase64String(merchantKey), new byte[8]);
            string signData = Convert.ToBase64String(myEnc.TransformFinalBlock(byteData, 0, byteData.Length));

            //Verfiy Method's parameters
            var myData = new
            {
                Token = callback.Token,
                SignData = signData
            };

            var res = CallApi<VerfiyResultData>("https://sadad.shaparak.ir/api/v0/Advice/Verify", myData).Result;
            if (res.ResCode == 0)
            {
                panelService.UpdatePayment(factorId, ShamsiDateTimeGenerator.GetShamsiDate(), ShamsiDateTimeGenerator.GetTimeInFormat(),
                                           res.Description, "سداد ملی", res.SystemTraceNo, res.RetrivalRefNo);

                return Redirect("/Panel/ResultPayment/" + factorId);
            }
            else
            {
                return Redirect("/Panel/ResultPayment/" + factorId);

            }
        }

        public async Task<T> CallApi<T>(string apiUrl, object value) where T : new()
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var json = JsonConvert.SerializeObject(value);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var w = client.PostAsync(apiUrl, content);
                w.Wait();
                HttpResponseMessage response = w.Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return JsonConvert.DeserializeObject<T>(result.Result);
                }
                return new T();
            }
        }

        public IActionResult Chat()
        {
            return View();
        }
    }
}
