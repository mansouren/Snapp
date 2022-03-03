using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snapp.Core.ViewModels.Profile;

namespace Snapp.Core.Interfaces
{
   public interface IPanelService : IDisposable
    {
        Task<UserDetail> GetUserDetail(string username);
        string GetRoleName(string username);
        bool UpdateUserDetailProfile(Guid id, UserDetailProfileViewModel viewModel);
        long GetPrice(double id);//id is distance in KM,we called it 'id' because of ajax callback
        float GetHumidityPercent(double id); //id is humidity degree
        float GetTempPercent(double id);//id is Temprature degree

        #region UserAddresses
        Task<List<UserAddress>> GetUserAddresses(Guid userid);
        void AddUserAddress(Guid id, UserAddressViewModel viewModel);
        #endregion

        #region Payment
        void AddFactor(Factor factor);
        bool UpdateFactor(Guid userid, string orderNo,long price);
        Guid GetFactor(string orderNo);
        Task<Factor> GetFactorById(Guid id);
        void UpdatePayment(Guid id, string date, string time, string desc,string bank, string trace, string refid);
        #endregion

        #region Transact
        Transact AddTransact(TransactViewModel viewModel);
        void UpdatePayment(Guid id);
        void UpdateRate(Guid id, int rate);
        void UpdateDriverRate(Guid id, bool rate);
        void UpdateStatus(Guid id, Status status);
        Task<Transact> GetTransactById(Guid id);
        Task<List<Transact>> GetUserTransacts(Guid id);
        Task<List<Transact>> GetDriverTransacts(Guid id);
        void UpdateDriver(Guid id, Guid driverId);
        #endregion
    }
}
