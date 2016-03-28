using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{

    [DataContract]
    public class RunPrintBillingsDTO : SAPResponse
     {
         [DataMember]
        public PrintBillingHeaderDTO _printBillingHeader { get; set; }

    }


    [DataContract]
    public class Contract : SAPResponse
    {
        [DataMember]
        public List<ContractItem> conItem { get; set; }

    }


       [DataContract]
    public class ContractItem 
       {
            [DataMember]
            public string VBELN{ get; set; }
	
            [DataMember]
            public string POSNR{ get; set; }
            [DataMember]
            public string AUBEL{ get; set; }
 	        [DataMember]
            public string AUPOS{ get; set; }
 	        [DataMember]
            public string MATKL{ get; set; }
 	        [DataMember]
            public string ITEM_TYPE{ get; set; }
 	        [DataMember]
            public string CATEGORY{ get; set; }
 	        [DataMember]
            public string SUBCATEGORY{ get; set; }
 	        [DataMember]
            public string WGBEZ{ get; set; }
 	        [DataMember]
            public string MATNR{ get; set; }
 	        [DataMember]
            public string ARKTX{ get; set; }
 	        [DataMember]
            public string FKIMG{ get; set; }
 	        [DataMember]
            public string VRKME{ get; set; }
 	        [DataMember]
            public string TOTAL1{ get; set; }
 	        [DataMember]
            public string TOTAL2{ get; set; }
 	        [DataMember]
            public string TOTAL3{ get; set; }
 	        [DataMember]
            public string TOTAL4{ get; set; }
 	        [DataMember]
            public string TOTAL5{ get; set; } 	
 	        [DataMember]
            public string VBAK_BSTKD_E{ get; set; }
 	        [DataMember]
            public string VBAK_SERGE{ get; set; }
 	        [DataMember]
            public string VBAK_LOCATION{ get; set; }
         	[DataMember]
            public string VBAK_PERNR2{ get; set; }
 	        [DataMember]
            public string VBAK_EMPNAME{ get; set; }
 	        [DataMember]
            public string VBAK_PERSAREA_T{ get; set; }
 	        [DataMember]
            public string VBAK_SUBAREA_T{ get; set; }
 	        [DataMember]
            public string VBAK_ORGUNIT_T{ get; set; }
 	        [DataMember]
            public string VBAK_OUCODE{ get; set; }
 	        [DataMember]
            public string VBAK_KOSTL{ get; set; }
 	        [DataMember]
            public string VBAK_WAERK{ get; set; }
 	        [DataMember]
            public string VBAK_BEDAT{ get; set; }
 	        [DataMember]
            public string VBAK_ENDAT{ get; set; }
 	        [DataMember]
            public string VBAK_ABGRU_T{ get; set; }
 	        [DataMember]
            public string VBAK_BSTKD{ get; set; }
 	        [DataMember]
            public string VBAK_BSTDK{ get; set; }
 	        [DataMember]
            public string VBAK_NAME{ get; set; }

 	        [DataMember]
            public string VBAK_FAKSK_T{ get; set; }
            [DataMember]
            public string VBAK_EQ_YEAR { get; set; }
            [DataMember]
            public string LogMessage { get; set; } //NOTO

    }


    [DataContract]
    public class PrintBillingHeaderDTO 
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
            [DataMember]
            public List<PrintBillingItemDTO> ReportInvoiceDetail { get; set; }

        }



        [DataContract]
        public class PrintBillingItemDTO
        {
            [DataMember]
            public string MaterialCategoryName { get; set; }
            [DataMember]
            public string Qty { get; set; }
            [DataMember]
            public string TotalCharges { get; set; }
            [DataMember]
            public List<MaterialSubCategory> MaterialSubCategoryLineViewModel { get; set; }
        }

        [DataContract]
        public class MaterialSubCategory 
        {
            [DataMember]
            public string MaterialSubCategoryName { get; set; }
            [DataMember]
            public string SubQty { get; set; }
            [DataMember]
            public string SubTotalCharges { get; set; }
            [DataMember]
            public List<DetailMaterialSubCategory> MaterialSubCategoryLineViewModel { get; set; }
        }

        [DataContract]
        public class DetailMaterialSubCategory
        {
            [DataMember]
            public string MaterialNo { get; set; }
            [DataMember]
            public string MatQty { get; set; }

            [DataMember]
            public string MatCharge { get; set; }
            [DataMember]
            public string MaterialDescription { get; set; }
            [DataMember]
            public string SubTotal { get; set; }

            [DataMember]
            public List<DetailSubMaterialDescription> DetailSubMaterialDescriptionLineViewModels { get; set; }
        }

        [DataContract]
        public class DetailSubMaterialDescription
        {
            [DataMember]
            public string No { get; set; }
            [DataMember]
            public string DetailSubDescription { get; set; }
            [DataMember]
            public string ChargesDetailSubMaterialDescription { get; set; }
        }



    }
