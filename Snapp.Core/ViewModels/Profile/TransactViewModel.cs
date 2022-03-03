using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Profile
{
   public class TransactViewModel
    {
        public Guid UserId { get; set; }

        public long Fee { get; set; }

        [Display(Name = "عرض جغرافیایی مبدا")]
        public string StartLatitude { get; set; }

        [Display(Name = "عرض جغرافیایی مقصد")]
        public string EndLatitude { get; set; }

        [Display(Name = "طول جغرافیایی مبدا")]
        public string StartLongtitude { get; set; }

        [Display(Name = "طول جغرافیایی مقصد")]
        public string EndLongtitude { get; set; }

        [Display(Name = "آدرس کامل مبدا")]
        public string StartAddress { get; set; }

        [Display(Name = "آدرس کامل مقصد")]
        public string EndAddress { get; set; }



    }
}
