using System;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.Termination
{
    [DataContract]
    public class TerminationItemDTO
    {
        private TerminatedContractDTO _terminatedContract;

        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string HolderName { get; set; }

        [DataMember]
        public string SalaryNumber { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Branch { get; set; }

        [DataMember]
        public string Application { get; set; }

        [DataMember]
        public DateTime RequestedDate { get; set; }

        [DataMember]
        public string RequestedBy { get; set; }

        [DataMember]
        public string ExtNumber { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public TerminatedContractDTO TerminatedContract
        {
            get { return _terminatedContract ?? (_terminatedContract = new TerminatedContractDTO()); }
            set { _terminatedContract = value; }
        }

        [DataMember]
        public string RejectionReason { get; set; }
    }
}