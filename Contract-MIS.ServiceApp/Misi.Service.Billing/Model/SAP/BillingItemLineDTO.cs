using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract]
    public class BillingItemLineDTO
    {
        private List<BillingSubItemLineDTO> _billingSubItemLines;
        
        [DataMember]
        public int ItemNumber { get; set; }

        [DataMember]
        public string ServiceId { get; set; }

        [DataMember]
        public string ReferenceId { get; set; }

        [DataMember]
        public string Scenario { get; set; }

        [DataMember]
        public string RequestedBy { get; set; }

        [DataMember]
        public string IssuedBy { get; set; }

        [DataMember]
        public DateTime IssuedDate { get; set; }

        [DataMember]
        public string SNorIDNumber { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime RequestedDate { get; set; }

        [DataMember]
        public string RequestedView { get; set; }

        [DataMember]
        public string RequestMemo { get; set; }

        public List<BillingSubItemLineDTO> BillingSubItemLines {
            get { return _billingSubItemLines ?? (_billingSubItemLines = new List<BillingSubItemLineDTO>()); }
            set { _billingSubItemLines = value; }
        }
    }
}