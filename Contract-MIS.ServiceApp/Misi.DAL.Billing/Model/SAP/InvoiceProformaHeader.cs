using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.Common.Lib.Util;

namespace Misi.DAL.Billing.Model.SAP
{
    public class InvoiceProformaHeader
    {
        private List<InvoiceProformaBilling> _billings;
        
        [Key]
        [Ignore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Ignore]
        [Column("billing_no")]
        public string BillingNo { get; set; }

        [Ignore]
        [Column("sold_to_party")]
        public string SoldToParty { get; set; }

        [Ignore]
        [Column("start_date", TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Ignore]
        [Column("end_date", TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        [Ignore]
        [Column("billing_block")]
        public bool BillingBlock { get; set; }

        [Ignore]
        [Column("reason_for_rejection")]
        public bool ReasonForRejection { get; set; }

        [Ignore]
        [Column("proforma_flag")]
        public bool ProformaFlag { get; set; }

        [Ignore]
        [Column("created", TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Ignore]
        [Column("version")]
        public int Version { get; set; }

        [Ignore]
        [Column("draft")]
        public bool Draft { get; set; }

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

        [Ignore]
        public List<InvoiceProformaBilling> Billings
        {
            get { return _billings ?? (_billings = new List<InvoiceProformaBilling>()); }
            set { _billings = value; }
        }
    }
}
