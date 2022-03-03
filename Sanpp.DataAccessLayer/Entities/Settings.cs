using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class Settings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Desc { get; set; }

        [Display(Name = "شماره تماس")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Tel { get; set; }

        [Display(Name = "شماره فکس")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Fax { get; set; }

        [Display(Name = "درباره ما")]
        public string About { get; set; }

        [Display(Name = "شرایط و قوانین")]
        public string Terms { get; set; }

        [Display(Name = "محاسبه قیمت با توجه به وضعیت آب و هوا")]
        public bool ConsiderWeatherForPrice { get; set; }

        [Display(Name = "محاسبه قیمت با توجه به بعد مسافت")]
        public bool ConsiderDistanceForPrice { get; set; }
    }
}
