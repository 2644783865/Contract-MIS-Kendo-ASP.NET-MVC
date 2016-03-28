using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Common
{
    public class Index
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("counter")]
        public long Counter { get; set; }

        [Column("unique_id")]
        public string UniqueId { get; set; }
    }
}
