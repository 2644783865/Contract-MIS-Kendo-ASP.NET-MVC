using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Object;

namespace Misi.DAL.Billing.Model.Common
{
    public abstract class ServiceRequestBase
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("scenario")]
        public EScenario Scenario { get; set; }

        [Column("issued_by")]
        public string IssuedBy { get; set; }

        [Column("issued_date", TypeName = "datetime2")]
        public DateTime IssuedDate { get; set; }

        [Column("state")]
        public EServiceRequestState State { get; set; }
    }
}
