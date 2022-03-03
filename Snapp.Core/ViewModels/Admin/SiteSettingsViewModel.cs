using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
   public class SiteSettingsViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage ="لطفا مقداری وارد کنید")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Tel { get; set; }

        [Display(Name = "شماره فکس")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Fax { get; set; }
    }
}
