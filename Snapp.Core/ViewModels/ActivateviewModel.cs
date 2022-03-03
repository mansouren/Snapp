using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels
{
   public class ActivateviewModel
    {
        [Display(Name = "کد 6 رقمی")]
        [Required(ErrorMessage = "لطفا کد 6 رقمی معتبر وارد کنید.")]
        [MaxLength(6, ErrorMessage = "لطفا کد 6 رقمی معتبر وارد کنید.")]
        [MinLength(6, ErrorMessage = "لطفا کد 6 رقمی معتبر وارد کنید.")]
        [Phone(ErrorMessage = "لطفا شماره موبایل معتبر وارد کنید.")] // because we want user just enter numbers
        public string Code { get; set; }
    }
}
