using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
   public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [Display(Name="عنوان نقش")]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [Display(Name = " نقش")]
        [MaxLength(30)]
        public string Name { get; set; }

        #region Relations
        public virtual ICollection<User> Users { get; set; }

        #endregion
    }
}
