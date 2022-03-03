using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class Discount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "کد تخفیف")]
        [MaxLength(10)]
        [Required]
        public string Code { get; set; }

        [Display(Name = "مبلغ تخفیف")]
        public long Price { get; set; }

        [Display(Name = "در صد تخفیف")]
        public int Percent { get; set; }

        [Display(Name = "سایر توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ شروع")]
        [MaxLength(10)]
        public string Start { get; set; }

        [Display(Name = "تاریخ پایان")]
        [MaxLength(10)]
        public string End { get; set; }

    }
}
