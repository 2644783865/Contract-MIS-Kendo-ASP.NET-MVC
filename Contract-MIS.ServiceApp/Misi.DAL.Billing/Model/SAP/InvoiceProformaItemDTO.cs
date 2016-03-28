using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Misi.Common.Lib.Util;

namespace Misi.Service.Billing.Object
{

    [DataContract]
    public class InvoiceProformaItemDTO
    {
        [Ignore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Ignore]
        [Column("cached_version")]
        public long CachedVersion { get; set; }

        [Ignore]
        [Column("remarks")]
        [DataMember]
        public string Remarks { get; set; }

        //-- Proforma
        [Ignore]
        [DataMember]
        public string NO { get; set; }
        [DataMember]
        public string VBELN { get; set; }
        [DataMember]
        public string POSNR { get; set; }
        [DataMember]
        public string AUBEL { get; set; }
        [DataMember]
        public string AUPOS { get; set; }
        [DataMember]
        public string MATKL { get; set; }
        [DataMember]
        public string ITEM_TYPE { get; set; }
        [DataMember]
        public string CATEGORY { get; set; }
        [DataMember]
        public string SUBCATEGORY { get; set; }
        [DataMember]
        public string WGBEZ { get; set; }
        [DataMember]
        public string MATNR { get; set; }
        [DataMember]
        public string ARKTX { get; set; }
        [DataMember]
        public string FKIMG { get; set; }
        [DataMember]
        public string VRKME { get; set; }
        [DataMember]
        public string TOTAL1 { get; set; }
        [DataMember]
        public string TOTAL2 { get; set; }
        [DataMember]
        public string TOTAL3 { get; set; }
        [DataMember]
        public string TOTAL4 { get; set; }
        [DataMember]
        public string TOTAL5 { get; set; }

        //-- VBAK
        [DataMember]
        public string VBAK_VBELN { get; set; }
        [DataMember]
        public string VBAK_POSNR { get; set; }
        [DataMember]
        public string VBAK_ZMENG { get; set; }
        [DataMember]
        public string VBAK_ZIEME { get; set; }
        [DataMember]
        public string VBAK_KONDM { get; set; }
        [DataMember]
        public string VBAK_VTEXT1 { get; set; }
        [DataMember]
        public string VBAK_BSTKD_E { get; set; }
        [DataMember]
        public string VBAK_EQUNR { get; set; }
        [DataMember]
        public string VBAK_TYPBZ { get; set; }
        [DataMember]
        public string VBAK_MAPAR { get; set; }
        [DataMember]
        public string VBAK_SERGE { get; set; }
        [DataMember]
        public string VBAK_LOCATION { get; set; }
        [DataMember]
        public string VBAK_PERNR1 { get; set; }
        [DataMember]
        public string VBAK_PERNR2 { get; set; }

        //-- Employee
        [DataMember]
        public string VBAK_EMPNAME { get; set; }
        [DataMember]
        public string VBAK_PERSAREA { get; set; }
        [DataMember]
        public string VBAK_PERSAREA_T { get; set; }
        [DataMember]
        public string VBAK_SUBAREA { get; set; }
        [DataMember]
        public string VBAK_SUBAREA_T { get; set; }
        [DataMember]
        public string VBAK_ORGUNIT { get; set; }
        [DataMember]
        public string VBAK_ORGUNIT_T { get; set; }

        [DataMember]
        public string VBAK_OUCODE { get; set; }
        [DataMember]
        public string VBAK_KOSTL { get; set; }
        [DataMember]
        public string VBAK_WAERK { get; set; }
        [DataMember]
        public string VBAK_NETWR { get; set; }
        [DataMember]
        public string VBAK_BEDAT { get; set; }
        [DataMember]
        public string VBAK_ENDAT { get; set; }
        [DataMember]
        public string VBAK_ABGRU_T { get; set; }
        [DataMember]
        public string VBAK_PS_PSP_PNR { get; set; }
        [DataMember]
        public string VBAK_PSTYV { get; set; }
        [DataMember]
        public string VBAK_KONDA { get; set; }
        [DataMember]
        public string VBAK_VTEXT2 { get; set; }
        [DataMember]
        public string VBAK_BSTKD { get; set; }
        [DataMember]
        public string VBAK_BSTDK { get; set; }
        [DataMember]
        public string VBAK_NAME { get; set; }
        [DataMember]
        public string VBAK_APPROVAL { get; set; }
        [DataMember]
        public string VBAK_NOTE { get; set; }
        [DataMember]
        public string VBAK_ADDRESS { get; set; }
        [DataMember]
        public string VBAK_FAKSK_T { get; set; }
        [DataMember]
        public string VBAK_EQ_YEAR { get; set; }
        [DataMember]
        public string LogMessage { get; set;}
    }
}
