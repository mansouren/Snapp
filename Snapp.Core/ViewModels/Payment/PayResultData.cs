using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Payment
{
    public class PayResultData
    {
        public int ResCode { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }

    }
}
