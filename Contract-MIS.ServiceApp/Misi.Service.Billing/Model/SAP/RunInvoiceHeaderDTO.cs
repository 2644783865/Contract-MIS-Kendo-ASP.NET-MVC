using System;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract]
    public class RunInvoiceHeaderDTO : RunInvoiceDTO
    {
        [DataMember]
        public DateTime BillingDateFrom { get; set; }

        [DataMember]
        public DateTime BillingDateTo { get; set; }

        [DataMember]
        public bool BillingDocsCriteria { get; set; }

        [DataMember]
        public bool ReasonForRejection { get; set; }

        [DataMember]
        public bool ProformaFlag { get; set; }

        [DataMember]
        public string BillingRun { get; set; }

        [DataMember]
        public string SoldToParty { get; set; }

        [DataMember]
        public string SoldToPartyName { get; set; }

        [DataMember]
        public string BillingNo { get; set; }

        [DataMember]
        public string BillingType { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string CreateOn { get; set; }

        [DataMember]
        public string Time { get; set; }

        [DataMember]
        public string Version { get; set; }

        public bool Draft { get; set; }

        public override string ToString()
        {
            return "FROM = " + BillingDateFrom + " - TO = " + BillingDateTo + " - BILL_BLOCK = " + BillingDocsCriteria +
                   " - REJECT = " + ReasonForRejection +
                   " - PROFLAG = " + ProformaFlag + " - " + " - S2PART" + SoldToParty + "- DRAFT = " + Draft;
        }
    }
}