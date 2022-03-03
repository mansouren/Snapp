using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class MonthTypeViewModel
    {
        [Display(Name = "عنوان ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        [Required(ErrorMessage = "لطفا مقداری وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "از ")]
        public int Start { get; set; }

        [Display(Name = "تا ")]
        public int End { get; set; }

        [Display(Name = "درصد")]
        public float Percent { get; set; }
    }
}
