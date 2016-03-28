using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Common
{
    public class Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
