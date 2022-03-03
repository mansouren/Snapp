using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
    public class RoleViewModel
    {

        [Display(Name = "عنوان سیستمی نقش")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage = "لطفا مقداری وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "عنوان نمایشی نقش")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage = "لطفا مقداری وارد کنید")]
        public string Title { get; set; }
    }
}
