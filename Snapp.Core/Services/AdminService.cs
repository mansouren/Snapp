using Microsoft.EntityFrameworkCore;
using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.Securities;
using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly SnappContext context;

        public AdminService(SnappContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public void AddCar(CarViewModel viewModel)
        {
            Car car = new Car
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name
            };

            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void DeleteCar(Guid id)
        {
            Car car = context.Cars.Find(id);
            if (car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }


        public async Task<Car> GetCarById(Guid id)
        {
            return await context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCars()
        {
            var cars = await context.Cars.OrderBy(c => c.Name).ToListAsync();
            return cars;
        }

        public bool UpdateCar(Guid id, CarViewModel viewModel)
        {
            Car car = context.Cars.Find(id);
            if (car != null)
            {
                car.Name = viewModel.Name;
                context.Cars.Update(car);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Color>> GetColors()
        {
            return await context.Colors.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Color> GetColorById(Guid id)
        {
            return await context.Colors.FindAsync(id);
        }

        public void AddColor(AdminColorViewModel viewModel)
        {
            Color color = new Color
            {
                Name = viewModel.Name,
                Code = viewModel.Code,
                Id = CodeGenerators.GetId()
            };
            context.Colors.Add(color);
            context.SaveChanges();
        }

        public bool UpdateColor(Guid id, AdminColorViewModel viewModel)
        {
            var color = context.Colors.Find(id);
            if (color != null)
            {
                color.Name = viewModel.Name;
                color.Code = viewModel.Code;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteColor(Guid id)
        {
            var color = context.Colors.Find(id);
            if (color != null)
            {
                context.Colors.Remove(color);
                context.SaveChanges();
            }
        }

        public async Task<List<RateType>> GetRateTypes()
        {
            return await context.RateTypes.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<RateType> GetRateTypeById(Guid id)
        {
            var rateType = await context.RateTypes.FindAsync(id);
            return rateType;
        }

        public void AddRateType(RateTypeViewModel viewModel)
        {
            RateType rateType = new()
            {
                Name = viewModel.Name,
                Ok = viewModel.Ok,
                Id = CodeGenerators.GetId(),
                ViewOrder = viewModel.ViewOrder
            };
            context.RateTypes.Add(rateType);
            context.SaveChanges();
        }

        public bool UpdateRateType(Guid id, RateTypeViewModel viewModel)
        {
            var rateType = context.RateTypes.Find(id);
            if (rateType != null)
            {
                rateType.Name = viewModel.Name;
                rateType.Ok = viewModel.Ok;
                rateType.ViewOrder = viewModel.ViewOrder;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public void DeleteRateType(Guid id)
        {
            var rateType = context.RateTypes.Find(id);
            if (rateType != null)
            {
                context.RateTypes.Remove(rateType);
                context.SaveChanges();
            }
        }

        public async Task<Settings> GetSettings()
        {
            return await context.Settings.FirstOrDefaultAsync();
        }

        public bool UpdateSiteSettings(SiteSettingsViewModel viewModel)
        {
            Settings settings = context.Settings.FirstOrDefault();
            if (settings != null)
            {
                settings.Name = viewModel.Name;
                settings.Tel = viewModel.Tel;
                settings.Fax = viewModel.Fax;
                settings.Desc = viewModel.Desc;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePriceSettings(PriceSettingViewModel viewModel)
        {
            Settings settings = context.Settings.FirstOrDefault();
            if (settings != null)
            {
                settings.ConsiderDistanceForPrice = viewModel.ConsiderDistanceForPrice;
                settings.ConsiderWeatherForPrice = viewModel.ConsiderWeatherForPrice;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAboutSettings(AboutSettingViewModel viewModel)
        {
            Settings settings = context.Settings.FirstOrDefault();
            if (settings != null)
            {
                settings.About = viewModel.About;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTermsSettings(TermsSettingViewModel viewModel)
        {
            Settings settings = context.Settings.FirstOrDefault();
            if (settings != null)
            {
                settings.Terms = viewModel.Terms;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<PriceType>> GetPriceTypes()
        {
            return await context.PriceTypes.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<PriceType> GetPriceTypeById(Guid id)
        {
            return await context.PriceTypes.FindAsync(id);
        }

        public void AddPriceType(PriceTypeViewModel viewModel)
        {
            PriceType priceType = new PriceType
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Start = viewModel.Start,
                End = viewModel.End,
                Price = viewModel.Price
            };
            context.PriceTypes.Add(priceType);
            context.SaveChanges();
        }

        public bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel)
        {
            PriceType priceType = context.PriceTypes.Find(id);
            if (priceType != null)
            {
                priceType.Name = viewModel.Name;
                priceType.Price = viewModel.Price;
                priceType.Start = viewModel.Start;
                priceType.End = viewModel.End;

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeletePriceType(Guid id)
        {
            PriceType priceType = context.PriceTypes.Find(id);
            if (priceType != null)
            {
                context.PriceTypes.Remove(priceType);
                context.SaveChanges();
            }
        }

        public async Task<List<MonthType>> GetMonthTypes()
        {
            return await context.MonthTypes.OrderBy(n => n.Name).ToListAsync();
        }

        public async Task<MonthType> GetMonthTypeById(Guid id)
        {
            return await context.MonthTypes.FindAsync(id);
        }

        public void AddMonthType(MonthTypeViewModel viewModel)
        {
            MonthType monthType = new MonthType
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Start = viewModel.Start,
                End = viewModel.End,
                Percent = viewModel.Percent
            };
            context.MonthTypes.Add(monthType);
            context.SaveChanges();
        }

        public bool UpdateMonthType(Guid id, MonthTypeViewModel viewModel)
        {
            MonthType monthType = context.MonthTypes.Find(id);
            if (monthType != null)
            {
                monthType.Name = viewModel.Name;
                monthType.Start = viewModel.Start;
                monthType.End = viewModel.End;
                monthType.Percent = viewModel.Percent;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public void DeleteMonthType(Guid id)
        {
            MonthType monthType = context.MonthTypes.Find(id);
            if (monthType != null)
            {
                context.MonthTypes.Remove(monthType);
                context.SaveChanges();
            }

        }

        public async Task<List<Humidity>> GetHumidityTypes()
        {
            return await context.Humidities.OrderBy(n => n.Name).ToListAsync();
        }

        public async Task<Humidity> GetHumidityTypeById(Guid id)
        {
            return await context.Humidities.FindAsync(id);
        }

        public void AddHumidityType(MonthTypeViewModel viewModel)
        {
            Humidity humidity = new Humidity
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Start = viewModel.Start,
                End = viewModel.End,
                Percent = viewModel.Percent
            };
            context.Humidities.Add(humidity);
            context.SaveChanges();
        }

        public bool UpdateHumidityType(Guid id, MonthTypeViewModel viewModel)
        {
            Humidity humidity = context.Humidities.Find(id);
            if (humidity != null)
            {
                humidity.Name = viewModel.Name;
                humidity.Start = viewModel.Start;
                humidity.End = viewModel.End;
                humidity.Percent = viewModel.Percent;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public void DeleteHumidityType(Guid id)
        {
            Humidity humidity = context.Humidities.Find(id);
            if (humidity != null)
            {
                context.Humidities.Remove(humidity);
                context.SaveChanges();
            }
        }

        public async Task<List<Temperature>> GetTemperatureTypes()
        {
            return await context.Temperatures.OrderBy(n => n.Name).ToListAsync();
        }

        public async Task<Temperature> GetTemperatureTypeById(Guid id)
        {
            return await context.Temperatures.FindAsync(id);
        }

        public void AddTemperatureType(MonthTypeViewModel viewModel)
        {
            Temperature temperature = new Temperature
            {
                Name = viewModel.Name,
                Start = viewModel.Start,
                End = viewModel.End,
                Percent = viewModel.End,
                Id = CodeGenerators.GetId()
            };
            context.Temperatures.Add(temperature);
            context.SaveChanges();
        }

        public bool UpdateTemperatureType(Guid id, MonthTypeViewModel viewModel)
        {
            Temperature temperature = context.Temperatures.Find(id);
            if (temperature != null)
            {
                temperature.Name = viewModel.Name;
                temperature.Start = viewModel.Start;
                temperature.End = viewModel.End;
                temperature.Percent = viewModel.Percent;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteTemperatureType(Guid id)
        {
            Temperature temperature = context.Temperatures.Find(id);
            if (temperature != null)
            {
                context.Temperatures.Remove(temperature);
                context.SaveChanges();
            }
        }

        public async Task<List<Role>> GetRoles()
        {
            return await context.Roles.OrderBy(n => n.Name).ToListAsync();
        }

        public async Task<Role> GetRoleById(Guid id)
        {
            return await context.Roles.FindAsync(id);
        }

        public void AddRole(RoleViewModel viewModel)
        {
            Role role = new Role
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Title = viewModel.Title
            };
            context.Roles.Add(role);
            context.SaveChanges();
        }

        public bool UpdateRole(Guid id, RoleViewModel viewModel)
        {
            var role = context.Roles.Find(id);
            if (role != null)
            {
                role.Name = viewModel.Name;
                role.Title = viewModel.Title;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteRole(Guid id)
        {
            var role = context.Roles.Find(id);
            if (role != null)
            {
                context.Roles.Remove(role);
                context.SaveChanges();
            }
        }

        public string GetRoleNameById(Guid id)
        {
            return context.Roles.Find(id).Name;
        }

        public bool CheckUserName(string mobile)
        {
            return context.Users.Any(u => u.UserName == mobile);
        }

        public void AddUser(UserViewModel viewModel)
        {
            User user = new User
            {
                UserName = viewModel.UserName,
                Password = HashPassword.GetHashPassword(HashPassword.GetHashPassword(CodeGenerators.GetActiveCode())),
                Id = CodeGenerators.GetId(),
                Isactive = viewModel.Isactive,
                RoleId = viewModel.RoleId,
                Token = null,
                Wallet = 0
            };
            context.Users.Add(user);

            UserDetail userDetail = new UserDetail
            {
                FullName = null,
                BirthDate = null,
                Date = ShamsiDateTimeGenerator.GetShamsiDate(),
                Time = ShamsiDateTimeGenerator.GetTimeInFormat(),
                UserId = user.Id
            };
            context.UserDetails.Add(userDetail);

            if (GetRoleNameById(user.RoleId) == "driver")
            {
                Driver driver = new Driver
                {
                    UserId = user.Id,
                    IsConfirmed = false
                };
                context.Drivers.Add(driver);
            }
            context.SaveChanges();
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users.Include(u => u.Role).OrderBy(u => u.UserName).ToListAsync();
        }

        public void DeleteUser(Guid id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public bool UpdateUser(UserEditViewModel viewModel, Guid id)
        {
            User user = context.Users.Find(id);
            UserDetail userDetail = context.UserDetails.Find(id);
            if (user != null)
            {
                user.Isactive = viewModel.Isactive;
                user.UserName = viewModel.UserName;
                user.RoleId = viewModel.RoleId;
                userDetail.BirthDate = viewModel.BirthDate;
                userDetail.FullName = viewModel.FullName;

                if (GetRoleNameById(viewModel.RoleId) == "driver")
                {
                    if (!context.Drivers.Any(d => d.UserId == id))
                    {
                        AddDriver(id);
                    }
                }
                else
                {
                    if (context.Drivers.Any(d => d.UserId == id))
                    {
                        DeleteDriver(id);
                    }
                }
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void AddDriver(Guid id)
        {
            Driver driver = new Driver
            {
                IsConfirmed = false,
                UserId = id
            };
            context.Drivers.Add(driver);
            context.SaveChanges();
        }

        public void DeleteDriver(Guid id)
        {
            var driver = context.Drivers.Find(id);
            if (driver != null)
            {
                context.Drivers.Remove(driver);
                context.SaveChanges();
            }
        }

        public bool CheckUserNameForUpdate(string username, Guid id)
        {
            bool exist = context.Users.Any(u => u.UserName == username && u.Id != id);
            return exist;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public bool UpdateDriver(DriverPropViewModel viewModel, Guid id)
        {
            Driver driver = context.Drivers.Find(id);

            if (viewModel.Avatar != null)
            {
                string strExtension = Path.GetExtension(viewModel.Avatar.FileName);
                if (strExtension != ".jpg")
                {
                    return false;
                }

                viewModel.AvatarName = CodeGenerators.GetFileName() + strExtension;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/driver/", viewModel.AvatarName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Avatar.CopyTo(stream);
                }

                if (driver.Avatar != null)
                {
                    File.Delete("wwwroot/images/driver/" + driver.Avatar);
                }

                driver.Avatar = viewModel.AvatarName;
                driver.Address = viewModel.Address;
                driver.Tel = viewModel.Tel;
                driver.NationalCode = viewModel.NationalCode;
                context.SaveChanges();
                return true;
            }
            if (driver.Avatar != null)
            {
                driver.Address = viewModel.Address;
                driver.Tel = viewModel.Tel;
                driver.NationalCode = viewModel.NationalCode;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Driver> GetDriver(Guid id)
        {
            return await context.Drivers.FindAsync(id);
        }

        public bool UpdareDriverCertificate(DriverCertificateViewModel viewModel, Guid id)
        {
            var driver = context.Drivers.Find(id);
            if (viewModel.CertificateImage != null)
            {
                var strExtenion = Path.GetExtension(viewModel.CertificateImage.FileName);
                viewModel.CertificateImageName = CodeGenerators.GetFileName() + strExtenion;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/driver/" + viewModel.CertificateImageName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.CertificateImage.CopyTo(stream);
                }
                if (driver.LicenceDocumentImg != null)
                {
                    File.Delete("wwwroot/images/driver/" + driver.LicenceDocumentImg);
                }
                driver.IsConfirmed = viewModel.IsConfirmed;
                driver.LicenceDocumentImg = viewModel.CertificateImageName;
                context.SaveChanges();
                return true;
            }
            if (driver.LicenceDocumentImg != null)
            {
                driver.IsConfirmed = viewModel.IsConfirmed;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateDriverCar(DriverCarViewModel viewModel, Guid id)
        {
            var driver = context.Drivers.Find(id);
            if (driver != null)
            {
                driver.CarId = viewModel.CarId;
                driver.ColorId = viewModel.ColorId;
                driver.CarNumber = viewModel.CarCode;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<UserDetail> GetUserDetail(Guid id)
        {
            return await context.UserDetails.FindAsync(id);
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            return await context.Discounts.OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(Guid id)
        {
            return await context.Discounts.FindAsync(id);
        }

        public void AddDiscount(AdminDiscountViewModel viewModel)
        {
            Discount discount = new Discount
            {
                Code = viewModel.Code,
                Name = viewModel.Name,
                Start = viewModel.Start,
                End = viewModel.End,
                Description = viewModel.Description,
                Percent = viewModel.Percent,
                Id = CodeGenerators.GetId(),
                Price = viewModel.Price
            };
            context.Discounts.Add(discount);
            context.SaveChanges();
        }

        public bool UpdateDiscount(AdminDiscountViewModel viewModel, Guid id)
        {
            Discount discount = context.Discounts.Find(id);
            if (discount != null)
            {
                discount.Name = viewModel.Name;
                discount.Price = viewModel.Price;
                discount.Code = viewModel.Code;
                discount.Start = viewModel.Start;
                discount.End = viewModel.End;
                discount.Description = viewModel.Description;
                discount.Percent = viewModel.Percent;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteDiscount(Guid id)
        {
            Discount discount = context.Discounts.Find(id);
            if (discount != null)
            {
                context.Discounts.Remove(discount);
                context.SaveChanges();
            }
        }

        public int WeeklyFactorChart(string date)
        {
            if(!context.Factors.Any(f => f.RefNumber != null && f.Date == date))
            {
                return 0;
            }
            int priceSum = context.Factors.Where(f => f.RefNumber != null && f.Date == date).Sum(f => f.Price);
            return priceSum;
        }

        public int MonthlyFactorChart(string month)
        {
            string thisYear = ShamsiDateTimeGenerator.GetShamsiDate().Substring(0, 4);
            if(!context.Factors.Any(f=> f.RefNumber !=null && f.Date.Substring(5,2) == month && f.Date.Substring(0,4) == thisYear))
            {
                return 0;
            }
           int totalMonthlyPrice = context.Factors.Where(f => f.RefNumber != null && f.Date.Substring(5, 2) == month && f.Date.Substring(0, 4) == thisYear).ToList().Sum(f => f.Price);
            return totalMonthlyPrice;
        }

        public int WeeklyUserRegisters(string date)
        {
            if(!context.Users.Include(u => u.UserDetail).Any(u => u.Isactive == true && u.UserDetail.Date == date))
            {
                return 0;
            }
            int activeUsercount = context.Users.Include(u => u.UserDetail)
                                  .Where(u => u.Isactive == true && u.UserDetail.Date == date).Count();
            return activeUsercount;

        }

        public int MonthlyRegisters(string month)
        {
            string thisYear = ShamsiDateTimeGenerator.GetShamsiDate().Substring(0, 4);
            if(!context.Users.Include(u => u.UserDetail)
                .Any(u => u.Isactive == true && u.UserDetail.Date.Substring(5,2) == month
                     && u.UserDetail.Date.Substring(0, 4) == thisYear))
            {
                return 0;
            }

            int monthlyRegisterUsers = context.Users.Include(u => u.UserDetail)
                .Where(u => u.Isactive == true && u.UserDetail.Date.Substring(5, 2) == month
                     && u.UserDetail.Date.Substring(0, 4) == thisYear).Count();
            
            return monthlyRegisterUsers;
        }

        public async Task<List<Transact>> GetTransacts()
        {
            return await context.Transacts.OrderByDescending(x => x.Date).ThenByDescending(x => x.StartTime).ToListAsync();
        }

        public void DeleteTransact(Guid id)
        {
            var transact = context.Transacts.Find(id);
            context.Transacts.Remove(transact);
            context.SaveChanges();
        }

        public async Task<List<TransactRate>> GetTransactRate(Guid id)
        {
            var transactrates = await context.TransactRates.Where(x => x.TransactId == id).ToListAsync();
            return transactrates;
        }
    }
}
