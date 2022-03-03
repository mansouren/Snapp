﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; } //This property is key and foreignkey at same time which is make one-to-one relation with user table

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [MaxLength(10)]
        public string Date { get; set; }

        [Display(Name = "ساعت عضویت")]
        [MaxLength(10)]
        public string Time { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(10)]
        public string BirthDate { get; set; }


        #region Relations
        public virtual User User { get; set; }
        #endregion
    }
}
