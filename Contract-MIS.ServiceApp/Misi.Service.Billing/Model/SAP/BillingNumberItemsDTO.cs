using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract]
    public class BillingNumberItemDTO
    {
        [DataMember]
        public string BillingDocNumber { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }
    }

    [DataContract]
    public class BillingNumberItemsDTO : SAPResponse
    {
        private List<BillingNumberItemDTO> _numbers;

        [DataMember]
        public List<BillingNumberItemDTO> Numbers
        {
            get { return _numbers ?? (_numbers = new List<BillingNumberItemDTO>()); }
            set { _numbers = value; }
        }
    }
}