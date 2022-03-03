using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "نام خودرو")]
        [MaxLength(100)]
        public string Name { get; set; }

        #region Relations
        public virtual ICollection<Driver> Drivers { get; set; }
        #endregion
    }
}
