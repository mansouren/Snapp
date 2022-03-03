using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class Transact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "مسافر")]
        public Guid UserId { get; set; }

        [Display(Name = "راننده")]
        public Guid? DriverId { get; set; }

        [Display(Name = "تاریخ سفر")]
        [MaxLength(10)]
        public string Date { get; set; }

        [Display(Name = "زمان تائید سفر")]
        [MaxLength(10)]
        public string StartTime { get; set; }

        [Display(Name = "زمان رسیدن به مقصد")]
        [MaxLength(10)]
        public string EndTime { get; set; }

        [Display(Name = "نقد")]
        public bool IsCash { get; set; }

        [Display(Name = "کرایه")]
        public long Fee { get; set; }

        [Display(Name = "مبلغ قابل پرداخت")]
        public long TotalPayment { get; set; }

        [Display(Name = "تخفیف")]
        public int Discount { get; set; }

        [Display(Name = "عرض جغرافیایی مبدا")]
        [MaxLength(20)]
        public string StartLatitude { get; set; }

        [Display(Name = "عرض جغرافیایی مقصد")]
        [MaxLength(20)]
        public string EndLatitude { get; set; }

        [Display(Name = "طول جغرافیایی مبدا")]
        [MaxLength(20)]
        public string StartLongtitude { get; set; }

        [Display(Name = "طول جغرافیایی مقصد")]
        [MaxLength(20)]
        public string EndLongtitude { get; set; }

        [Display(Name = "آدرس کامل مبدا")]
        public string StartAddress { get; set; }

        [Display(Name = "آدرس کامل مقصد")]
        public string EndAddress { get; set; }

        [Display(Name = "امتیاز")]
        public int Rate { get; set; }

        [Display(Name = "امتیاز راننده")]
        public bool DriverRate { get; set; }

        public Status Status { get; set; }

        #region Relations

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public virtual ICollection<TransactRate> TransactRates { get; set; }
        #endregion
    }

    public enum Status
    {
        Create = 0,
        UpdateDriver = 1,
        Success=2,
        Cancel=3
        
    }
}
