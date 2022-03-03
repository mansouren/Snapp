using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class DriverPropViewModel
    {
        
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        [MaxLength(10,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Phone(ErrorMessage ="لطفا کد ملی معتبر وارد کنید")]
        public string NationalCode { get; set; }

        
        [Display(Name = "تلفن ثابت")]
        [MaxLength(30,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        
        public string AvatarName { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile Avatar { get; set; }
    }
}
