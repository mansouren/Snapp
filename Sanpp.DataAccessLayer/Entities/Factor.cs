using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class Factor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام کاربر")]
        public Guid UserId { get; set; }

        [Display(Name = "تاریخ")]
        [MaxLength(10)]
        public string Date { get; set; }

        [Display(Name = "ساعت")]
        [MaxLength(10)]
        public string Time { get; set; }

        [Display(Name = "شماره سفارش")]
        [MaxLength(8)]
        public string OrderNumber { get; set; }

        [Display(Name = "مبلغ")]
        public int Price { get; set; }

        [Display(Name = "شماره ارجاع")]
        [MaxLength(50)]
        public string RefNumber { get; set; }

        [Display(Name = "شماره پیگیری")]
        [MaxLength(50)]
        public string TraceNumber { get; set; }

        [Display(Name = "درگاه")]
        public string BankName { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        #region Relations
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        #endregion
    }
}
