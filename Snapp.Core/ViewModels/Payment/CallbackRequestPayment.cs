using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Payment
{
   public class CallbackRequestPayment
    {
        public string PrimaryAccountNumber { get; set; }
        public string HashedCartNumber { get; set; }
        public long OrderId { get; set; }
        public string SwitchResCode { get; set; }
        public string ResCode { get; set; }
        public string Token { get; set; }
    }
}
