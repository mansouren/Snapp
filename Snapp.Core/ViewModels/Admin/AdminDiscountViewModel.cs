using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class AdminDiscountViewModel
    {
        [Display(Name = "عنوان")]
        [MaxLength(100,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "کد تخفیف")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage = "لطفا مقداری وارد کنید")]
        public string Code { get; set; }

        [Display(Name = "مبلغ تخفیف")]
        public long Price { get; set; }

        [Display(Name = "در صد تخفیف")]
        public int Percent { get; set; }

        [Display(Name = "سایر توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "تاریخ شروع")]
        [MaxLength(10)]
        public string Start { get; set; }

        [Display(Name = "تاریخ پایان")]
        [MaxLength(10)]
        public string End { get; set; }
    }
}
