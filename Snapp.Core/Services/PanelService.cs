using Microsoft.EntityFrameworkCore;
using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Profile;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Services
{
    public class PanelService : IPanelService
    {
        private readonly SnappContext context;

        public PanelService(SnappContext context)
        {
            this.context = context;
        }

        public void AddFactor(Factor factor)
        {
            context.Factors.Add(factor);
            context.SaveChanges();
        }

        public Transact AddTransact(TransactViewModel viewModel)
        {
            Transact transact = new Transact()
            {
                Id = CodeGenerators.GetId(),
                Date = ShamsiDateTimeGenerator.GetShamsiDate(),
                StartTime = ShamsiDateTimeGenerator.GetTimeInFormat(),
                Fee = viewModel.Fee,
                Discount = 0,
                DriverId = null,
                StartAddress = viewModel.StartAddress,
                StartLatitude = viewModel.StartLatitude,
                StartLongtitude = viewModel.StartLongtitude,
                EndAddress = viewModel.EndAddress,
                EndLatitude = viewModel.EndLatitude,
                EndLongtitude = viewModel.EndLongtitude,
                EndTime = null,
                IsCash = false,
                UserId = viewModel.UserId,
                Status = 0,
                DriverRate = false,
                Rate = 0,
                TotalPayment = viewModel.Fee
            };
            context.Transacts.Add(transact);
            context.SaveChanges();
            return transact;
        }

        public void AddUserAddress(Guid id, UserAddressViewModel viewModel)
        {
            UserAddress userAddress = new UserAddress()
            {
                Id = CodeGenerators.GetId(),
                UserId = id,
                Desc = viewModel.Desc,
                Lat = viewModel.Lat,
                lng = viewModel.lng,
                Title = viewModel.Title
            };
            context.UserAddresses.Add(userAddress);
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public async Task<List<Transact>> GetDriverTransacts(Guid id)
        {
            return await context.Transacts.Where(x => x.DriverId == id && x.Status == Status.Success).OrderByDescending(x => x.Date).ToListAsync();
        }

        public Guid GetFactor(string orderNo)
        {
            Factor factor = context.Factors.SingleOrDefault(f => f.OrderNumber == orderNo);
            return factor.Id;
        }

        public async Task<Factor> GetFactorById(Guid id)
        {
            return await context.Factors.FindAsync(id);
        }

        public float GetHumidityPercent(double id)
        {
            var humidity = context.Humidities.FirstOrDefault(h => h.End >= id && h.Start <= id);
            if(humidity == null)
            {
                return 0;
            }
            float res = Convert.ToSingle(humidity.Percent / 100);
            return res;
        }

        public long GetPrice(double id) //در اینجا مسافت محاسبه شده همان id است
        {
            var priceType = context.PriceTypes.FirstOrDefault(p => p.End >= id && p.Start <= id);
            if(priceType == null)
            {
                return 0;
            }
            return priceType.Price;
        }

        public string GetRoleName(string username)
        {
           return context.Users.Include(u => u.Role).SingleOrDefault(u => u.UserName == username).Role.Name;
        }

        public float GetTempPercent(double id)
        {
            var temp = context.Temperatures.FirstOrDefault(t => t.End >= id && t.Start <= id);
            if(temp == null)
            {
                return 0;
            }
            float res = Convert.ToSingle(temp.Percent / 100);
            return res;
        }

        public async Task<Transact> GetTransactById(Guid id)
        {
            return await context.Transacts.FindAsync(id);
        }

        public async Task<List<UserAddress>> GetUserAddresses(Guid userid)
        {
            var result = await context.UserAddresses.Where(u => u.UserId == userid).ToListAsync();
            return result;
        }

        public async Task<UserDetail> GetUserDetail(string username)
        {
            var result = await context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.UserName == username);
            return result;
        }

        public async Task<List<Transact>> GetUserTransacts(Guid id)
        {
            return await context.Transacts.Where(x => x.UserId == id && x.Status == Status.Success)
                                          .OrderByDescending(x => x.Date).ToListAsync();
        }

        public void UpdateDriver(Guid id, Guid driverId)
        {
            var transact = context.Transacts.Find(id);
            transact.DriverId = driverId;
            context.SaveChanges();
        }

        public void UpdateDriverRate(Guid id, bool rate)
        {
            var transact = context.Transacts.Find(id);
            transact.DriverRate = rate;
            context.SaveChanges();
        }

        public bool UpdateFactor(Guid userid, string orderNo, long price)
        {
            Factor factor = context.Factors.SingleOrDefault(f => f.UserId == userid && f.BankName == null);
            if(factor != null)
            {
                factor.OrderNumber = orderNo;
                factor.Price =Convert.ToInt32(price);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdatePayment(Guid id, string date, string time, string desc, string bank, string trace, string refid)
        {
            Factor factor = context.Factors.Find(id);
            User user = context.Users.Find(factor.UserId);

            factor.Date = date;
            factor.Time = time;
            factor.Description = desc;
            factor.BankName = bank;
            factor.TraceNumber = trace;
            factor.RefNumber = refid;
            user.Wallet += factor.Price;

            context.SaveChanges();
        }

        public void UpdatePayment(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRate(Guid id, int rate)
        {
            var transact = context.Transacts.Find(id);
            transact.Rate = rate;
            context.SaveChanges();
        }

        public void UpdateStatus(Guid id, Status status)
        {
            var transact = context.Transacts.Find(id);
            transact.Status = status;
            context.SaveChanges();
        }

        public bool UpdateUserDetailProfile(Guid id, UserDetailProfileViewModel viewModel)
        {
            UserDetail userDetail = context.UserDetails.Find(id);
            if(userDetail != null)
            {
                userDetail.FullName = viewModel.FullName;
                userDetail.BirthDate = viewModel.BirthDate;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
