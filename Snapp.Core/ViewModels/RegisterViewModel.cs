using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels
{
   public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="لطفا شماره موبایل معتبر وارد کنید.")]
        [MaxLength(11, ErrorMessage = "لطفا شماره موبایل معتبر وارد کنید.")]
        [MinLength(11,ErrorMessage = "لطفا شماره موبایل معتبر وارد کنید.")]
        [Phone(ErrorMessage = "لطفا شماره موبایل معتبر وارد کنید.")]
        public string UserName { get; set; }
    }
}
