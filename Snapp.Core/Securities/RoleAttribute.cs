using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Snapp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Securities
{
    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string roleName;
        private IAccountService accountService;
        public RoleAttribute(string roleName)
        {
            this.roleName = roleName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Identity.Name;

                accountService = (IAccountService)context.HttpContext.RequestServices.GetService(typeof(IAccountService));
                bool result = accountService.GetUserRole(roleName, userName);
                if (!result)
                {
                    context.Result = new RedirectResult("/Account/Register");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Register");
            }
        }
    }
}
