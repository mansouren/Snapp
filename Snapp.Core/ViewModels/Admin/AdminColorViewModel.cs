using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
    public class AdminColorViewModel
    {
        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage = "لطفا مقداری وارد کنید")]
        [MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        [Display(Name = "کد رنگ")]
        [MaxLength(10,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        public string Code { get; set; }
    }
}
