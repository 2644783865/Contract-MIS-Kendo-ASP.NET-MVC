using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Object;

namespace Misi.DAL.Billing.Model.Common
{
    public class RoutingItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Column("step")]
        public long Step { get; set; }

        [Column("division")]
        public string Division { get; set; }

        [Column("instruction")]
        public string Instruction { get; set; }

        [Column("response")]
        public string Response { get; set; }

        [Column("base_date", TypeName = "datetime2")]
        public DateTime BaseDate { get; set; }

        [Column("plan_date", TypeName = "datetime2")]
        public DateTime PlanDate { get; set; }

        [Column("actual_date", TypeName = "datetime2")]
        public DateTime ActualDate { get; set; }

        [Column("division_state")]
        public bool DivisionState { get; set; }

        [Column("as_state")]
        public bool SaState { get; set; }

        [Column("routing_status")]
        public ERoutingStatus RoutingStatus { get; set; }
    }
}
