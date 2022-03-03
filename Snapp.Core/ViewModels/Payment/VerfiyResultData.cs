using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Payment
{
   public class VerfiyResultData
    {
        public int ResCode { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string RetrivalRefNo { get; set; }
        public string SystemTraceNo { get; set; }
        public int OrderId { get; set; }

    }
}
