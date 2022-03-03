using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
    public class UserViewModel
    {
        [Display(Name = " نقش کاربر")]
        public Guid RoleId { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [MinLength(11,ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage = "لطفا مقداری وارد کنید")]
        [Phone(ErrorMessage ="لطفا شماره موبایل معتبر وارد کنید")]
        public string UserName { get; set; }


        [Display(Name = "فعال/غیرفعال")]
        public bool Isactive { get; set; }
    }
}
