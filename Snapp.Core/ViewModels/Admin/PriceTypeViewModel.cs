using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
    public class PriceTypeViewModel
    {
        [Display(Name = "عنوان تعرفه")]
        [MaxLength(100,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "از مسافت")]
        public int Start { get; set; }

        [Display(Name = "تا مسافت")]
        public int End { get; set; }

        [Display(Name = "نرخ ثابت")]
        public long Price { get; set; }
    }
}
