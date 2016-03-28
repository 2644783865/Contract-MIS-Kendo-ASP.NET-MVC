using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Common
{
    public abstract class RequestInfoBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("request_memo")]
        public string RequestMemo { get; set; }
    }
}
