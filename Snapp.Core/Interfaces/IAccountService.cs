using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Interfaces
{
   public interface IAccountService : IDisposable
    {
        bool CheckMobile(string username);
        Task<User> RegisterUser(RegisterViewModel viewModel);
        Task<User> RegisterDriver(RegisterViewModel viewModel);
        Guid GetRoleByName(string rolename);
        Task<User> GetUser(string username);
        void UpdateUserPassword(Guid id, string code);
        Task<User> ActivateUser(ActivateviewModel viewModel);
        bool GetUserRole(string role, string username);
    }
}
