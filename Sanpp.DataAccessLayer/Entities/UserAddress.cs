using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "کاربر")]
        public Guid UserId { get; set; }

        [Display(Name = "نام یا عنوان")]
        [MaxLength(40)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "طول جغرافیایی")]
        [MaxLength(20)]
        [Required]
        public string Lat { get; set; }

        [Display(Name = "عرض جغرافیایی")]
        [MaxLength(30)]
        [Required]
        public string lng { get; set; }

        [Display(Name = "آدرس")]
        [Required]
        public string Desc { get; set; }

        #region Relations

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        #endregion
    }
}
