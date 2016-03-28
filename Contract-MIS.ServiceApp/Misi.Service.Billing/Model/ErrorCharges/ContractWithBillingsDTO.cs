using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.ErrorCharges
{
    [DataContract]
    public class ContractWithBillingsDTO
    {
        private List<ContractBillingDTO> _billings;

        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string HolderName { get; set; }

        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string LineNumber { get; set; }

        [DataMember]
        public string Material { get; set; }

        [DataMember]
        public long Quantity { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public string MaterialDesc { get; set; }

        [DataMember]
        public string ItemCategory { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public decimal Charges { get; set; }

        [DataMember]
        public string ReasonForRjection { get; set; }

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

        [DataMember]
        public List<ContractBillingDTO> Billings
        {
            get { return _billings ?? (_billings = new List<ContractBillingDTO>()); }
            set { _billings = value; }
        } 
    }

    [DataContract]
    public class ContractBillingDTO
    {
        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string SubItem { get; set; }

        [DataMember]
        public DateTime PlanDate { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public decimal Charges { get; set; }

        [DataMember]
        public decimal Actual { get; set; }

        [DataMember]
        public decimal Deduction { get; set; }
    }
}