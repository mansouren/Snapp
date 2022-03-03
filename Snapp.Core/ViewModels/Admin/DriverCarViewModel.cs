using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
    public class DriverCarViewModel
    {
        [Display(Name = "انتخاب خودرو")]
        public Guid? CarId { get; set; }

        [Display(Name = "انتخاب رنگ")]
        public Guid? ColorId { get; set; }

        [Display(Name = "پلاک خودرو")]
        public string CarCode { get; set; }
    }
}
