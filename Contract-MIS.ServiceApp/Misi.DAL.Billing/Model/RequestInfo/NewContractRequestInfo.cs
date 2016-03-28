using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.RequestInfo
{
    public class NewContractRequestInfo : CommonIssueRequestInfo
    {
        [Column("requested_by")]
        public string RequestedBy { get; set; }

        [Column("location")]
        public string Location { get; set; }
    }
}
