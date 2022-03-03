using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.Securities;
using Snapp.Core.Senders;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Services
{
    public class AccountService : IAccountService
    {
        private SnappContext context;

        public AccountService(SnappContext context)
        {
            this.context = context;
        }

        public async Task<User> ActivateUser(ActivateviewModel viewModel)
        {
            string password = viewModel.Code;
            //string password = HashPassword.GetHashPassword(HashPassword.GetHashPassword(viewModel.Code));
            var user = context.Users.SingleOrDefault(u => u.Password == password);
            if (user != null)
            {
                user.Isactive = true;
                user.Password = CodeGenerators.GetActiveCode();
                //user.Password = HashPassword.GetHashPassword(HashPassword.GetHashPassword(CodeGenerators.GetActiveCode()));
                context.SaveChanges();
            }
            return await Task.FromResult(user);

        }

        public bool CheckMobile(string username)
        {
            bool exist = context.Users.Any(u => u.UserName == username);
            return exist;
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public Guid GetRoleByName(string rolename)
        {
            return context.Roles.SingleOrDefault(r => r.Name == rolename).Id;
        }

        public async Task<User> GetUser(string username)
        {
            User user = context.Users.SingleOrDefault(u => u.UserName == username);
            return await Task.FromResult(user);
        }

        public bool GetUserRole(string role, string username)
        {
            Role myRole = context.Roles.SingleOrDefault(r => r.Name == role);
            return context.Users.Any(u => u.UserName == username && u.RoleId == myRole.Id);
        }

        public async Task<User> RegisterDriver(RegisterViewModel viewModel)
        {
            if (!CheckMobile(viewModel.UserName))
            {
                string code = CodeGenerators.GetActiveCode();

                User user = new User
                {
                    Id = CodeGenerators.GetId(),
                    Isactive = false,
                    Token = null,
                    UserName = viewModel.UserName,
                    //Password = HashPassword.GetHashPassword(HashPassword.GetHashPassword(code)), //Hashing password twice for more security
                    Password = code,
                    RoleId = GetRoleByName("driver")
                };

                context.Users.Add(user);

                UserDetail userDetail = new()
                {
                    FullName = null,
                    Date = ShamsiDateTimeGenerator.GetShamsiDate(),
                    Time = ShamsiDateTimeGenerator.GetTimeInFormat(),
                    BirthDate = null,
                    UserId = user.Id
                };

                context.UserDetails.Add(userDetail);
                Driver driver = new Driver
                {
                    UserId = user.Id,
                    IsConfirmed = false
                };

                context.Drivers.Add(driver);
                context.SaveChanges();

                try
                {

                    SendSms.VerifySend(user.UserName, "", code);
                }
                catch (Exception)
                {

                    throw;
                }

                return await Task.FromResult(user);
            }
            else
            {
                User user = await GetUser(viewModel.UserName);
                string code = CodeGenerators.GetActiveCode();
                UpdateUserPassword(user.Id, code);
                try
                {

                    SendSms.VerifySend(user.UserName, "", code);
                }
                catch (Exception)
                {

                    throw;
                }
                return await Task.FromResult(user);
            }
        }

        public async Task<User> RegisterUser(RegisterViewModel viewModel)
        {
            if (!CheckMobile(viewModel.UserName))
            {
                string code = CodeGenerators.GetActiveCode();

                User user = new User
                {
                    Id = CodeGenerators.GetId(),
                    Isactive = false,
                    Token = null,
                    UserName = viewModel.UserName,
                    Password = HashPassword.GetHashPassword(HashPassword.GetHashPassword(code)), //Hashing password twice for more security
                    RoleId = GetRoleByName("user")
                };

                context.Users.Add(user);

                UserDetail userDetail = new()
                {
                    FullName = null,
                    Date = ShamsiDateTimeGenerator.GetShamsiDate(),
                    Time = ShamsiDateTimeGenerator.GetTimeInFormat(),
                    BirthDate = null,
                    UserId = user.Id
                };

                context.UserDetails.Add(userDetail);
                context.SaveChanges();
                try
                {

                    SendSms.VerifySend(user.UserName, "", code);
                }
                catch (Exception)
                {

                    throw;
                }

                return await Task.FromResult(user);
            }
            else
            {
                User user = await GetUser(viewModel.UserName);
                string code = CodeGenerators.GetActiveCode();
                UpdateUserPassword(user.Id, code);
                try
                {

                    SendSms.VerifySend(user.UserName, "", code);
                }
                catch (Exception)
                {

                    throw;
                }
                return await Task.FromResult(user);
            }
        }

        public void UpdateUserPassword(Guid id, string code)
        {
            User user = context.Users.Find(id);
            user.Password = code;
            //user.Password = HashPassword.GetHashPassword(HashPassword.GetHashPassword(code));
            context.SaveChanges();
        }
    }
}
