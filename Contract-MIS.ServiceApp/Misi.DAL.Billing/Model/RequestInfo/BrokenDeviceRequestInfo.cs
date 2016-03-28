using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.RequestInfo
{
    public class BrokenDeviceRequestInfo : CommonIssueRequestInfo
    {
        [Column("requested_by")]
        public string RequestedBy { get; set; }

        [Column("customer_id")]
        public string CustomerId { get; set; }

        [Column("branch")]
        public string Branch { get; set; }
    }
}
