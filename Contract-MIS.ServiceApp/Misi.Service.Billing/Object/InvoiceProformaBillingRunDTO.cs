using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.SAP;

namespace Misi.Service.Billing.Object
{
    [DataContract]
    public class InvoiceProformaBillingRunsDTO : SAPResponse
    {
        private List<InvoiceProformaBillingRunDTO> _list;

        public List<InvoiceProformaBillingRunDTO> Items {
            get { return _list ?? (_list = new List<InvoiceProformaBillingRunDTO>()); }
            set { _list = value; }
        }
    }

    [DataContract]
    public class InvoiceProformaBillingRunDTO
    {
        [DataMember]
        public int No { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public string SoldToParty { get; set; }
        [DataMember]
        public bool Draft { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
    }
}