using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Interfaces
{
    public interface IAdminService : IDisposable
    {
        #region Cars
        Task<List<Car>> GetCars();
        Task<Car> GetCarById(Guid id);
        void AddCar(CarViewModel viewModel);
        bool UpdateCar(Guid id, CarViewModel viewModel);
        void DeleteCar(Guid id);
        #endregion

        #region Colors
        Task<List<Color>> GetColors();
        Task<Color> GetColorById(Guid id);
        void AddColor(AdminColorViewModel viewModel);
        bool UpdateColor(Guid id, AdminColorViewModel viewModel);
        void DeleteColor(Guid id);
        #endregion

        #region RateType
        Task<List<RateType>> GetRateTypes();
        Task<RateType> GetRateTypeById(Guid id);
        void AddRateType(RateTypeViewModel viewModel);
        bool UpdateRateType(Guid id, RateTypeViewModel viewModel);
        void DeleteRateType(Guid id);
        #endregion

        #region Settings
        Task<Settings> GetSettings();
        bool UpdateSiteSettings(SiteSettingsViewModel viewModel);
        bool UpdatePriceSettings(PriceSettingViewModel viewModel);
        bool UpdateAboutSettings(AboutSettingViewModel viewModel);
        bool UpdateTermsSettings(TermsSettingViewModel viewModel);
        #endregion

        #region PriceType
        Task<List<PriceType>> GetPriceTypes();
        Task<PriceType> GetPriceTypeById(Guid id);
        void AddPriceType(PriceTypeViewModel viewModel);
        bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel);
        void DeletePriceType(Guid id);
        #endregion

        #region MonthType
        Task<List<MonthType>> GetMonthTypes();
        Task<MonthType> GetMonthTypeById(Guid id);
        void AddMonthType(MonthTypeViewModel viewModel);
        bool UpdateMonthType(Guid id, MonthTypeViewModel viewModel);
        void DeleteMonthType(Guid id);
        #endregion

        #region HumidityType
        Task<List<Humidity>> GetHumidityTypes();
        Task<Humidity> GetHumidityTypeById(Guid id);
        void AddHumidityType(MonthTypeViewModel viewModel);
        bool UpdateHumidityType(Guid id, MonthTypeViewModel viewModel);
        void DeleteHumidityType(Guid id);
        #endregion

        #region TemperatureType
        Task<List<Temperature>> GetTemperatureTypes();
        Task<Temperature> GetTemperatureTypeById(Guid id);
        void AddTemperatureType(MonthTypeViewModel viewModel);
        bool UpdateTemperatureType(Guid id, MonthTypeViewModel viewModel);
        void DeleteTemperatureType(Guid id);
        #endregion

        #region Role
        Task<List<Role>> GetRoles();
        Task<Role> GetRoleById(Guid id);
        void AddRole(RoleViewModel viewModel);
        bool UpdateRole(Guid id, RoleViewModel viewModel);
        void DeleteRole(Guid id);
        #endregion

        #region User
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task<UserDetail> GetUserDetail(Guid id);
        string GetRoleNameById(Guid id);
        bool CheckUserName(string mobile);
        void AddUser(UserViewModel viewModel);
        void DeleteUser(Guid id);
        bool UpdateUser(UserEditViewModel viewModel, Guid id);
        void AddDriver(Guid id);
        void DeleteDriver(Guid id);
        bool CheckUserNameForUpdate(string username, Guid id);
        Task<Driver> GetDriver(Guid id);
        bool UpdateDriver(DriverPropViewModel viewModel, Guid id);
        bool UpdareDriverCertificate(DriverCertificateViewModel viewModel, Guid id);
        bool UpdateDriverCar(DriverCarViewModel viewModel, Guid id);
        #endregion

        #region Discount
        Task<List<Discount>> GetDiscounts();
        Task<Discount> GetDiscountById(Guid id);
        void AddDiscount(AdminDiscountViewModel viewModel);
        bool UpdateDiscount(AdminDiscountViewModel viewModel, Guid id);
        void DeleteDiscount(Guid id);
        #endregion

        #region Charts
        int WeeklyFactorChart(string date);
        int MonthlyFactorChart(string month);
        int WeeklyUserRegisters(string date);
        int MonthlyRegisters(string month);
        #endregion

        #region Transacts
        Task<List<Transact>> GetTransacts();
        void DeleteTransact(Guid id);
        Task<List<TransactRate>> GetTransactRate(Guid id);
        #endregion
    }
}
