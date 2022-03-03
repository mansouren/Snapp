using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Profile
{
   public class FactorViewModel
    {
        [Display(Name = "کیف پول")]
        public long Wallet { get; set; }
    }
}
