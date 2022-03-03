using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Profile
{
   public class UserAddressViewModel
    {
        [Display(Name = "نام یا عنوان")]
        [MaxLength(40,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        public string Title { get; set; }

        
        public string Lat { get; set; }

        
        public string lng { get; set; }

        
        public string Desc { get; set; }
    }
}
