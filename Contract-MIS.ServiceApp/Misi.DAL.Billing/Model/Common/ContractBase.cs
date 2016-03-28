using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Common
{
    public abstract class ContractBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }
    }
}
