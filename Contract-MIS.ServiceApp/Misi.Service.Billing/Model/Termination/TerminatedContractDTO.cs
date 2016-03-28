using System;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.Termination
{
    [DataContract]
    public class TerminatedContractDTO : ContractBaseDTO
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string LineNumber { get; set; }

        [DataMember]
        public string Material { get; set; }

        [DataMember]
        public string MaterialDesc { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public long Quantity { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public string ItemCategory { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public decimal Charges { get; set; }

        [DataMember]
        public string WbsElement { get; set; }

        [DataMember]
        public string PurchaseOrder { get; set; }

        [DataMember]
        public string PoNumber { get; set; }

        [DataMember]
        public string MaterialPricing { get; set; }

        [DataMember]
        public string PriceGroup { get; set; }
    }
}