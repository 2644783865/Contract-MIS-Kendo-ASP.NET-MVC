using System;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class PreviewRoutingInfoLineViewModel
    {
        [LocalizedDisplayName("SubItem", NameResourceType = typeof (Resources.SharedResource))]
        public string SubItem { get; set; }

        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("SoldToParty", NameResourceType = typeof (Resources.SharedResource))]
        public string SoldToParty { get; set; }

        [LocalizedDisplayName("HolderNameDetails", NameResourceType = typeof (Resources.SharedResource))]
        public string HolderNameDetails { get; set; }

        [LocalizedDisplayName("SoContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string SoContractNumber { get; set; }

        [LocalizedDisplayName("lineNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string LineNumber { get; set; }

        [LocalizedDisplayName("Material", NameResourceType = typeof (Resources.SharedResource))]
        public string Material { get; set; }

        [LocalizedDisplayName("TargetQty", NameResourceType = typeof (Resources.SharedResource))]
        public int TargetQty { get; set; }

        [LocalizedDisplayName("Unit", NameResourceType = typeof (Resources.SharedResource))]
        public string Unit { get; set; }

        [LocalizedDisplayName("MaterialDescription", NameResourceType = typeof (Resources.SharedResource))]
        public string MaterialDescription { get; set; }

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

        [LocalizedDisplayName("ActualCharges", NameResourceType = typeof (Resources.SharedResource))]
        public double ActualCharges { get; set; }

        [LocalizedDisplayName("Deduction", NameResourceType = typeof (Resources.SharedResource))]
        public double Deduction { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof (Resources.SharedResource))]
        public string ReasonForRejection { get; set; }

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

        [LocalizedDisplayName("SaStatus", NameResourceType = typeof (Resources.SharedResource))]
        public bool SaStatus { get; set; }

        [LocalizedDisplayName("AmStatus", NameResourceType = typeof (Resources.SharedResource))]
        public bool AmStatus { get; set; }

        [LocalizedDisplayName("BaStatus", NameResourceType = typeof (Resources.SharedResource))]
        public bool BaStatus { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (Resources.SharedResource))]
        public string RoutingStatus { get; set; }
    }
}