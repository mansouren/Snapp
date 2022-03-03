using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class RateTypeViewModel
    {
        [Display(Name = "گزینه امتیاز")]
        [MaxLength(40,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "مثبت")]
        public bool Ok { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int ViewOrder { get; set; }
    }
}
