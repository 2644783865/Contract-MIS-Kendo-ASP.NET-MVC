using System;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.RequestInfo
{
    public abstract class CommonIssueRequestInfo : RequestInfoBase
    {
        [Column("requested_date", TypeName = "datetime2")]
        public DateTime RequestedDate { get; set; }

        [Column("sn_or_id_number")]
        public string SnOrIdNumber { get; set; }

        [Column("company")]
        public string Company { get; set; }
    }
}
