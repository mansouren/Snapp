using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
    public class DriverCertificateViewModel
    {
        [Display(Name = "تائید/عدم تائید")]
        public bool IsConfirmed { get; set; }
        public IFormFile CertificateImage { get; set; }

        [Display(Name = "تصویر گواهینامه")]
        public string CertificateImageName { get; set; }
    }
}
