using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام رنگ")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "کد رنگ")]
        public string Code { get; set; }

        #region Relations
        public virtual ICollection<Driver> Drivers { get; set; }
        #endregion
    }
}
