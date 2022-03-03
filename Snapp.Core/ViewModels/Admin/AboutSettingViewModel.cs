using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class AboutSettingViewModel
    {
        [Display(Name = "درباره ما")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }
}
