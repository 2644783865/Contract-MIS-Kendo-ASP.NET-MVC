using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Common.Lib.Util;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract]
    public class BillingItemDTO
    {
        private List<BillingItemLineDTO> _billingItemLines;

        [SAPDataField("NO")]
        [DataMember]
        public long No { get; set; }

        [SAPDataField("POSNR")]
        [DataMember]
        public int BillingItem { get; set; }

        [SAPDataField("TOTAL5")]
        [DataMember]
        public double Charge { get; set; }

        [SAPDataField("ITEM_TYPE")]
        [DataMember]
        public string Type { get; set; }

        [SAPDataField("WGBEZ")]
        [DataMember]
        public string MaterialType { get; set; }

        [SAPDataField("MATNR")]
        [DataMember]
        public string MaterialNo { get; set; }

        [SAPDataField("ARKTX")]
        [DataMember]
        public string Description { get; set; }

        [SAPDataField("VBAK_EQUNR")]
        [DataMember]
        public string Equipment { get; set; }

        [SAPDataField("VBAK_SERGE")]
        [DataMember]
        public string SerialNumber { get; set; }

        [SAPDataField("VBAK_LOCATION")]
        [DataMember]
        public string Location { get; set; }

        [SAPDataField("VBAK_PERNR2")]
        [DataMember]
        public string SalaryNumber { get; set; }

        [SAPDataField("VBAK_EMPNAME")]
        [DataMember]
        public string HolderName { get; set; }

        [SAPDataField("VBAK_SUBAREA_T")]
        [DataMember]
        public string SubArea { get; set; }

        [SAPDataField("VBAK_EQ_YEAR")]
        [DataMember]
        public string Year { get; set; }

        [SAPDataField("LogMessage")]
        [DataMember]
        public string LogMessage { get; set; } //NOTO

        [SAPDataField("VBAK_WAERK")]
        [DataMember]
        public string Currency { get; set; }

        [SAPDataField("TOTAL4")]
        [DataMember]
        public double Deduction { get; set; }

        [SAPDataField("AUBEL")]
        [DataMember]
        public string ContractNumber { get; set; }

        [SAPDataField("AUPOS")]
        [DataMember]
        public int ContractItem { get; set; }

        [SAPDataField("VBAK_BSTKD")]
        [DataMember]
        public string IdrWebNumber { get; set; }

        [SAPDataField("VBAK_BSTDK")]
        [DataMember]
        public DateTime IdrDate { get; set; }

        [SAPDataField("VBAK_BEDAT")]
        [DataMember]
        public DateTime ValidFrom { get; set; }

        [SAPDataField("VBAK_ENDAT")]
        [DataMember]
        public DateTime ValidTo { get; set; }

        [SAPDataField("VBAK_PERSAREA_T")]
        [DataMember]
        public string PersArea { get; set; }

        [SAPDataField("VBAK_ORGUNIT_T")]
        [DataMember]
        public string OrgUnit { get; set; }

        [SAPDataField("VBAK_OUCODE")]
        [DataMember]
        public string OuCode { get; set; }

        [SAPDataField("VBAK_KOSTL")]
        [DataMember]
        public string CostCenter { get; set; }

        [DataMember]
        public string OriginMatCode { get; set; }

        [SAPDataField("VBAK_NAME")]
        [DataMember]
        public string OtherInformation { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [SAPDataField("VBAK_FAKSK_T")]
        [DataMember]
        public string BillingBlock { get; set; }

        [SAPDataField("VBAK_ABGRU_T")]
        [DataMember]
        public string ReasonForRejection { get; set; }

        [DataMember]
        public List<BillingItemLineDTO> BillingItemLines {
            get { return _billingItemLines ?? (_billingItemLines = new List<BillingItemLineDTO>()); }
            set { _billingItemLines = value; }
        }
    }

}