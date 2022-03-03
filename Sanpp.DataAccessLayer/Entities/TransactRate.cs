using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
   public class TransactRate
    {
        public Guid Id { get; set; }
        public Guid TransactId { get; set; }
        public Guid RateTypeId { get; set; }

        #region Relations

        [ForeignKey(nameof(TransactId))]
        public virtual Transact Transact { get; set; }

        [ForeignKey(nameof(RateTypeId))]
        public virtual RateType RateType { get; set; }

        #endregion
    }
}
