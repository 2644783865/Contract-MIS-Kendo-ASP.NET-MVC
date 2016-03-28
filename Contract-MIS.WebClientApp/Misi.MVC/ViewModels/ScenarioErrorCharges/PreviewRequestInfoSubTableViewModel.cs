using System;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class PreviewRequestInfoSubTableViewModel
    {
        [LocalizedDisplayName("Item", NameResourceType = typeof (SharedResource))]
        public int Item { get; set; }

        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("SoldToParty", NameResourceType = typeof (SharedResource))]
        public string SoldToParty { get; set; }

        [LocalizedDisplayName("HolderNameDetails", NameResourceType = typeof (SharedResource))]
        public string HolderNameDetails { get; set; }

        [LocalizedDisplayName("SoContractNumber", NameResourceType = typeof (SharedResource))]
        public int SoContractNumber { get; set; }

        [LocalizedDisplayName("LineNumber", NameResourceType = typeof (SharedResource))]
        public int LineNumber { get; set; }

        [LocalizedDisplayName("Material", NameResourceType = typeof (SharedResource))]
        public string Material { get; set; }

        [LocalizedDisplayName("TargetQty", NameResourceType = typeof (SharedResource))]
        public int TargetQty { get; set; }

        [LocalizedDisplayName("Unit", NameResourceType = typeof (SharedResource))]
        public string Unit { get; set; }

        [LocalizedDisplayName("MaterialDescription", NameResourceType = typeof (SharedResource))]
        public string MaterialDescription { get; set; }

        [LocalizedDisplayName("ItemCategory", NameResourceType = typeof (SharedResource))]
        public string ItemCategory { get; set; }

        [LocalizedDisplayName("ContractStart", NameResourceType = typeof (SharedResource))]
        public DateTime ContractStart { get; set; }

        [LocalizedDisplayName("ContractEnd", NameResourceType = typeof (SharedResource))]
        public DateTime ContractEnd { get; set; }

        [LocalizedDisplayName("Currency", NameResourceType = typeof (SharedResource))]
        public string Currency { get; set; }

        [LocalizedDisplayName("Charges", NameResourceType = typeof (SharedResource))]
        public int Charges { get; set; }

        [LocalizedDisplayName("ActualCharges", NameResourceType = typeof (SharedResource))]
        public int ActualCharges { get; set; }

        [LocalizedDisplayName("Deduction", NameResourceType = typeof (SharedResource))]
        public int Deduction { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof (SharedResource))]
        public string ReasonForRejection { get; set; }

        [LocalizedDisplayName("WbsElement", NameResourceType = typeof (SharedResource))]
        public int WbsElement { get; set; }

        [LocalizedDisplayName("PurchaseOrder", NameResourceType = typeof (SharedResource))]
        public int PurchaseOrder { get; set; }

        [LocalizedDisplayName("PoNumber", NameResourceType = typeof (SharedResource))]
        public int PoNumber { get; set; }

        [LocalizedDisplayName("MaterialPricing", NameResourceType = typeof (SharedResource))]
        public string MaterialPricing { get; set; }

        [LocalizedDisplayName("PriceGroup", NameResourceType = typeof (SharedResource))]
        public string PriceGroup { get; set; }

        [LocalizedDisplayName("SaStatus", NameResourceType = typeof (SharedResource))]
        public string SaStatus { get; set; }

        [LocalizedDisplayName("AmStatus", NameResourceType = typeof (SharedResource))]
        public string AmStatus { get; set; }

        [LocalizedDisplayName("BaStatus", NameResourceType = typeof (SharedResource))]
        public string BaStatus { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (SharedResource))]
        public string RoutingStatus { get; set; }
    }
}