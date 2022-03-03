using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = " انتخاب نقش")]
        public Guid RoleId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required]
        [MaxLength(11)]
        public string UserName { get; set; }

        [Display(Name = "کد ورود")] //we get password as an activationCode in sms and because we made this code in codegenerator class and it makes random 6 numbers,we have set maxlength to 6 digit
        [MaxLength(100)]
        public string Password { get; set; }

        [Display(Name = " توکن")]
        public string Token { get; set; }

        [Display(Name = "کیف پول")]
        public long Wallet { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool Isactive { get; set; }

        #region Relations

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Factor> Factors { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<Transact> Transacts { get; set; }
        #endregion
    }
}
