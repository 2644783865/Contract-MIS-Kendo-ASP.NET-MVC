
using System.Collections.Generic;

namespace Misi.Service.Billing.Model.SAP
{
    public class InvoiceProformaJoin
    {
        //-- Header
        
        public string VBELN { get; set; }

        public string KUNRG { get; set; }
        
        public string NAME1 { get; set; }
        
        public string NAME2 { get; set; }
        
        public string NAME3 { get; set; }
        
        public string NAME4 { get; set; }
        
        public string STREET { get; set; }
        
        public string CITY1 { get; set; }
        
        public string POST_CODE1 { get; set; }
        
        public string FKDAT { get; set; }
        
        public string STCEG { get; set; }
        
        public string TDLINE { get; set; }
        
        public string TDLINE2 { get; set; }
        
        public string ZTERM { get; set; }
        
        public string TEXT1 { get; set; }
        
        public string HTOTAL1 { get; set; }
        
        public string HTOTAL2 { get; set; }
        
        public string HTOTAL3 { get; set; }
        
        public string HTOTAL4 { get; set; }
        
        public string HTOTAL5 { get; set; }
        
        public string VTEXT { get; set; }
        
        public string ERNAM { get; set; }
        
        public string ERDAT { get; set; }
        
        public string ERZET { get; set; }
        
        public string WAERK { get; set; }
        
        public string KURRF { get; set; }
        
        public string FPAJAK_NO { get; set; }

        //-- Billing
        
        public string POSNR { get; set; }
        
        public string AUBEL { get; set; }
        
        public string AUPOS { get; set; }
        
        public string MATKL { get; set; }
        
        public string CATEGORY { get; set; }
        
        public string SUBCATEGORY { get; set; }
        
        public string WGBEZ { get; set; }
        
        public string MATNR { get; set; }
        
        public string ARKTX { get; set; }
        
        public string FKIMG { get; set; }
        
        public string VRKME { get; set; }
        
        public string TOTAL1 { get; set; }
        
        public string TOTAL2 { get; set; }
        
        public string TOTAL3 { get; set; }
        
        public string TOTAL4 { get; set; }
        
        public string TOTAL5 { get; set; }

        //-- Proforma
        
        public string VBAK_VBELN { get; set; }
        
        public string VBAK_POSNR { get; set; }
        
        public string VBAK_ZMENG { get; set; }
        
        public string VBAK_ZIEME { get; set; }
        
        public string VBAK_KONDM { get; set; }
        
        public string VBAK_VTEXT1 { get; set; }
        
        public string VBAK_BSTKD_E { get; set; }
        
        public string VBAK_EQUNR { get; set; }
        
        public string VBAK_TYPBZ { get; set; }
        
        public string VBAK_MAPAR { get; set; }
        
        public string VBAK_SERGE { get; set; }
        
        public string VBAK_PERNR1 { get; set; }
        
        public string VBAK_PERNR2 { get; set; }
        
        public string VBAK_KOSTL { get; set; }
        
        public string VBAK_WAERK { get; set; }
        
        public string VBAK_NETWR { get; set; }
        
        public string VBAK_BEDAT { get; set; }
        
        public string VBAK_ENDAT { get; set; }
        
        public string VBAK_ABGRU { get; set; }
        
        public string VBAK_PS_PSP_PNR { get; set; }
        
        public string VBAK_PSTYV { get; set; }
        
        public string VBAK_KONDA { get; set; }
        
        public string VBAK_VTEXT2 { get; set; }
        
        public string VBAK_BSTKD { get; set; }
        
        public string VBAK_BSTDK { get; set; }
        
        public string VBAK_NAME { get; set; }
        
        public string VBAK_APPROVAL { get; set; }
        
        public string VBAK_NOTE { get; set; }
        
        public string VBAK_ADDRESS { get; set; }
        
        public string VBAK_FAKSK { get; set; }

        //-- Employee
        
        public string VBAK_EMPNAME { get; set; }
        
        public string VBAK_PERSAREA { get; set; }
        
        public string VBAK_PERSAREA_T { get; set; }
        
        public string VBAK_SUBAREA { get; set; }
        
        public string VBAK_SUBAREA_T { get; set; }
        
        public string VBAK_ORGUNIT { get; set; }
        
        public string VBAK_ORGUNIT_T { get; set; }
        
        public string VBAK_LOCATION { get; set; }
    }

    public class InvoiceProformaJoins
    {
        private List<InvoiceProformaJoin> _joins;

        public List<InvoiceProformaJoin> Joins
        {
            get { return _joins ?? (_joins = new List<InvoiceProformaJoin>()); }
            set { _joins = value; }
        }
    }
}