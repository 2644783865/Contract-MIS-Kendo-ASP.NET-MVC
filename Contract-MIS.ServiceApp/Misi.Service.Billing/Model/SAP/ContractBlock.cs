using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP


{
    [DataContract]
    public class ContractBlock : SAPResponse
    {
        [DataMember]
        public string ContractNo { get; set; }

        [DataMember]
        public string ContractItem { get; set; }

        [DataMember]
        public string ReasonForRejected { get; set; }

        [DataMember]
        public string BillingBlock { get; set; }

    }
}