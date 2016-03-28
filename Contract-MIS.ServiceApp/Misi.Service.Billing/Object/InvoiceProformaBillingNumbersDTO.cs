using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Object
{
    [DataContract]
    public class InvoiceProformaBillingNumbersDTO
    {
        private List<InvoiceProformaBillingNumberDTO> _numbers;

        [DataMember]
        public List<InvoiceProformaBillingNumberDTO> Numbers
        {
            get { return _numbers ?? (_numbers = new List<InvoiceProformaBillingNumberDTO>()); }
            set { _numbers = value; }
        }
    }

    [DataContract]
    public class InvoiceProformaBillingNumberDTO
    {
        [DataMember]
        public string VBELN { get; set; }
        [DataMember]
        public string KUNRG { get; set; }
        [DataMember]
        public string NAME1 { get; set; }
        [DataMember]
        public string NAME2 { get; set; }
        [DataMember]
        public string NAME3 { get; set; }
        [DataMember]
        public string NAME4 { get; set; }
        [DataMember]
        public string STREET { get; set; }
        [DataMember]
        public string CITY1 { get; set; }
        [DataMember]
        public string POST_CODE1 { get; set; }
        [DataMember]
        public string FKDAT { get; set; }
        [DataMember]
        public string STCEG { get; set; }
        [DataMember]
        public string TDLINE { get; set; }
        [DataMember]
        public string TDLINE2 { get; set; }
        [DataMember]
        public string ZTERM { get; set; }
        [DataMember]
        public string TEXT1 { get; set; }
        [DataMember]
        public string HTOTAL1 { get; set; }
        [DataMember]
        public string HTOTAL2 { get; set; }
        [DataMember]
        public string HTOTAL3 { get; set; }
        [DataMember]
        public string HTOTAL4 { get; set; }
        [DataMember]
        public string HTOTAL5 { get; set; }
        [DataMember]
        public string VTEXT { get; set; }
        [DataMember]
        public string ERNAM { get; set; }
        [DataMember]
        public string ERDAT { get; set; }
        [DataMember]
        public string ERZET { get; set; }
        [DataMember]
        public string WAERK { get; set; }
        [DataMember]
        public string KURRF { get; set; }
        [DataMember]
        public string FPAJAK_NO { get; set; }
    }
}