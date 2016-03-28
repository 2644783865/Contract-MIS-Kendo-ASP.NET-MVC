using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.RequestInfo
{
    public class ReturnDeviceRequestInfo : CommonIssueRequestInfo
    {
        [Column("location")]
        public string Location { get; set; }

        [Column("requested_by")]
        public string RequestedBy { get; set; }

        [Column("requested_via")]
        public string RequestedVia { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
