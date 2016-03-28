using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.Common
{
    public class TerminationItem
    {
        private TerminatedContract _contractRef;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Column("company")]
        public string Company { get; set; }

        [Column("holder_name")]
        public string HolderName { get; set; }

        [Column("salary_number")]
        public string SalaryNumber { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("branch")]
        public string Branch { get; set; }

        [Column("application")]
        public string Application { get; set; }

        [Column("requested_date", TypeName = "datetime2")]
        public DateTime RequestedDate { get; set; }

        [Column("requested_by")]
        public string RequestedBy { get; set; }

        [Column("ext_number")]
        public string ExtNumber { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("rejection_reason")]
        public string RejectionReason { get; set; }

        public TerminatedContract TerminatedContract
        {
            get { return _contractRef ?? (_contractRef = new TerminatedContract()); }
            set { _contractRef = value; }
        }
    }
}
