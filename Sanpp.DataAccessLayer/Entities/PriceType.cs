using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class PriceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "عنوان تعرفه")]
        public string Name { get; set; }

        [Display(Name = "از مسافت")]
        public int Start { get; set; }

        [Display(Name = "تا مسافت")]
        public int End { get; set; }

        [Display(Name = "نرخ ثابت")]
        public long Price { get; set; }
    }
}
