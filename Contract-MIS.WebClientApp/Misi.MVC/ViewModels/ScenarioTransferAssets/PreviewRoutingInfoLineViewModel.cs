using System;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class PreviewRoutingInfoLineViewModel
    {
        [LocalizedDisplayName("SubItem", NameResourceType = typeof (Resources.SharedResource))]
        public string SubItem { get; set; }

        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractNumber { get; set; }

        [LocalizedDisplayName("ContractNumberLine", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractLineNumber { get; set; }

        //part of Predefined Scenario
        [LocalizedDisplayName("ScenarioName", NameResourceType = typeof (Resources.SharedResource))]
        public string ScenarioName { get; set; }

        //part of Predefined Scenario
        [LocalizedDisplayName("TransferAssetType", NameResourceType = typeof (Resources.SharedResource))]
        public string TransferAssetType { get; set; }

        //part of Equipment or Service
        [LocalizedDisplayName("Equipment", NameResourceType = typeof (Resources.SharedResource))]
        public string Equipment { get; set; }

        //part of Equipment or Service
        [LocalizedDisplayName("EquipmentDescription", NameResourceType = typeof (Resources.SharedResource))]
        public string EquipmentDescription { get; set; }

        [LocalizedDisplayName("Device", NameResourceType = typeof (Resources.SharedResource))]
        public string Device { get; set; }

        [LocalizedDisplayName("SnDevice", NameResourceType = typeof (Resources.SharedResource))]
        public string SnDevice { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (Resources.SharedResource))]
        public string RoutingMemo { get; set; }

        [LocalizedDisplayName("DivisionStatus", NameResourceType = typeof (Resources.SharedResource))]
        public bool DivisionStatus { get; set; }

        [LocalizedDisplayName("SaStatus", NameResourceType = typeof (Resources.SharedResource))]
        public bool SaStatus { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (Resources.SharedResource))]
        public string RoutingStatus { get; set; }

        [LocalizedDisplayName("BillingBlock", NameResourceType = typeof (Resources.SharedResource))]
        public bool BillingBlock { get; set; }

        [LocalizedDisplayName("BlockingStatus", NameResourceType = typeof (Resources.SharedResource))]
        public string BlockingStatus { get; set; }
    }
}