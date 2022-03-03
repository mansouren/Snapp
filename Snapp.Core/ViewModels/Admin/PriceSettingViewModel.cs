using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class PriceSettingViewModel
    {
        [Display(Name = "محاسبه قیمت با توجه به وضعیت آب و هوا")]
        public bool ConsiderWeatherForPrice { get; set; }

        [Display(Name = "محاسبه قیمت با توجه به بعد مسافت")]
        public bool ConsiderDistanceForPrice { get; set; }
    }
}
