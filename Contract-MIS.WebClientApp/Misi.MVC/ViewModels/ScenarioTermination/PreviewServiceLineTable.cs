using System;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class PreviewServiceLineTable
    {
        [LocalizedDisplayName("Item", NameResourceType = typeof (Resources.SharedResource))]
        public int Item { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (Resources.SharedResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("HolderName", NameResourceType = typeof (Resources.SharedResource))]
        public string HolderName { get; set; }

        [LocalizedDisplayName("Sn", NameResourceType = typeof (Resources.SharedResource))]
        public int Sn { get; set; }

        [LocalizedDisplayName("UserId", NameResourceType = typeof (Resources.SharedResource))]
        public string UserId { get; set; }

        [LocalizedDisplayName("Application", NameResourceType = typeof (Resources.SharedResource))]
        public string Application { get; set; }

        [LocalizedDisplayName("Status", NameResourceType = typeof (Resources.SharedResource))]
        public string Status { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractNumber { get; set; }

        [LocalizedDisplayName("LineNumber", NameResourceType = typeof (Resources.SharedResource))]
        public int LineNumber { get; set; }

        [LocalizedDisplayName("Material", NameResourceType = typeof (Resources.SharedResource))]
        public string Material { get; set; }

        [LocalizedDisplayName("TargetQty", NameResourceType = typeof (Resources.SharedResource))]
        public int TargetQty { get; set; }

        [LocalizedDisplayName("Unit", NameResourceType = typeof (Resources.SharedResource))]
        public string Unit { get; set; }

        [LocalizedDisplayName("MaterialDescription", NameResourceType = typeof (Resources.SharedResource))]
        public string MaterialDescription { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof (Resources.SharedResource))]
        public string ReasonForRejection { get; set; }

        [LocalizedDisplayName("ItemCategory", NameResourceType = typeof (Resources.SharedResource))]
        public string ItemCategory { get; set; }

        [LocalizedDisplayName("ContractStart", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime ContractStart { get; set; }

        [LocalizedDisplayName("ContractEnd", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime ContractEnd { get; set; }

        [LocalizedDisplayName("Currency", NameResourceType = typeof (Resources.SharedResource))]
        public string Currency { get; set; }

        [LocalizedDisplayName("Charges", NameResourceType = typeof (Resources.SharedResource))]
        public double Charges { get; set; }

        [LocalizedDisplayName("WbsElement", NameResourceType = typeof (Resources.SharedResource))]
        public string WbsElement { get; set; }

        [LocalizedDisplayName("PurchaseOrder", NameResourceType = typeof (Resources.SharedResource))]
        public string PurchaseOrder { get; set; }

        [LocalizedDisplayName("PoNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string PoNumber { get; set; }

        [LocalizedDisplayName("MaterialPricing", NameResourceType = typeof (Resources.SharedResource))]
        public string MaterialPricing { get; set; }

        [LocalizedDisplayName("PriceGroup", NameResourceType = typeof (Resources.SharedResource))]
        public string PriceGroup { get; set; }
    }
}