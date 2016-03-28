using System;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.Contract
{
    public class TerminatedContract : ContractBase
    {
        [Column("number")]
        public string Number { get; set; }

        [Column("line_number")]
        public string LineNumber { get; set; }

        [Column("material")]
        public string Material { get; set; }

        [Column("material_desc")]
        public string MaterialDesc { get; set; }

        [Column("start_date", TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column("end_date", TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        [Column("quantity")]
        public long Quantity { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("item_category")]
        public string ItemCategory { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("charges")]
        public decimal Charges { get; set; }

        [Column("wbs_element")]
        public string WbsElement { get; set; }

        [Column("purchase_order")]
        public string PurchaseOrder { get; set; }

        [Column("po_number")]
        public string PoNumber { get; set; }

        [Column("material_pricing")]
        public string MaterialPricing { get; set; }

        [Column("price_group")]
        public string PriceGroup { get; set; }
    }
}
