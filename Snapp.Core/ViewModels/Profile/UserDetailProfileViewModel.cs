using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Profile
{
   public class UserDetailProfileViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        [MaxLength(100,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string FullName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }
    }
}
