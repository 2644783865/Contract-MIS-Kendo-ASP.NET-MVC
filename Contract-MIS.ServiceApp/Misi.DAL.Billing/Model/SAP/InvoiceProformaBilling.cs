using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.Common.Lib.Util;

namespace Misi.DAL.Billing.Model.SAP
{
    public class InvoiceProformaBilling
    {
        [Ignore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Ignore]
        [Column("cached_version")]
        public long CachedVersion { get; set; }

        [Ignore]
        [Column("remarks")]
        public string Remarks { get; set; }

        public string VBELN { get; set; }
        public string POSNR { get; set; }
        public string AUBEL { get; set; }
        public string AUPOS { get; set; }
        public string MATKL { get; set; }
        public string ITEM_TYPE { get; set; }
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

        //-- VBAK
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
        public string VBAK_LOCATION { get; set; }
        public string VBAK_PERNR1 { get; set; }
        public string VBAK_PERNR2 { get; set; }

        //-- Employee
        public string VBAK_EMPNAME { get; set; }
        public string VBAK_PERSAREA { get; set; }
        public string VBAK_PERSAREA_T { get; set; }
        public string VBAK_SUBAREA { get; set; }
        public string VBAK_SUBAREA_T { get; set; }
        public string VBAK_ORGUNIT { get; set; }
        public string VBAK_ORGUNIT_T { get; set; }

        public string VBAK_OUCODE { get; set; }
        public string VBAK_KOSTL { get; set; }
        public string VBAK_WAERK { get; set; }
        public string VBAK_NETWR { get; set; }
        public string VBAK_BEDAT { get; set; }
        public string VBAK_ENDAT { get; set; }
        public string VBAK_ABGRU_T { get; set; }//-- Reason for rejection
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
        public string VBAK_FAKSK_T { get; set; }
        public string VBAK_EQ_YEAR { get; set; }
        public string LogMessage { get; set; }
    }
}
