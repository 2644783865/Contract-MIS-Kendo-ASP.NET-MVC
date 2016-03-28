using System;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.Contract
{
    public class ContractBilling : ContractBase
    {
        [Column("sub_item")]
        public string SubItem { get; set; }

        [Column("plan_date", TypeName = "datetime2")]
        public DateTime PlanDate { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("charges")]
        public decimal Charges { get; set; }

        [Column("actual")]
        public decimal Actual { get; set; }

        [Column("deduction")]
        public decimal Deduction { get; set; }
    }
}
