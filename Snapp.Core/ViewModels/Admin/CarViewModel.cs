using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class CarViewModel
    {
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        [Display(Name = "نام خودرو")]
        [MaxLength(100,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }
    }
}
