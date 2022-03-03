using Snapp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Scopes
{
    public class SiteLayoutScope
    {
        private readonly IPanelService panelService;

        public SiteLayoutScope(IPanelService panelService)
        {
            this.panelService = panelService;
        }

        public string GetUserRole(string username)
        {
           return panelService.GetRoleName(username);
        }
    }
}
