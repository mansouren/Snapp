using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
   public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey(nameof(User))] //One-to-One
        public Guid UserId { get; set; }

        public Guid? CarId { get; set; }
        public Guid? ColorId { get; set; }

        [MaxLength(10)]
        [Display(Name ="کد ملی")]
        public string NationalCode { get; set; }

        [MaxLength(30)]
        [Display(Name = "تلفن ثابت")]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "شماره پلاک خودرو")]
        [MaxLength(30)]
        public string CarNumber { get; set; }

        [Display(Name = "گواهینامه")]
        public string LicenceDocumentImg { get; set; } 
        
        [Display(Name = "تصویر راننده")]
        public string Avatar { get; set; }

         [Display(Name = "تائید")]
        public bool IsConfirmed { get; set; }

        #region Relations
        public virtual User User { get; set; }

        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }

        [ForeignKey(nameof(ColorId))]
        public virtual Color Color { get; set; }
        #endregion
    }
}
