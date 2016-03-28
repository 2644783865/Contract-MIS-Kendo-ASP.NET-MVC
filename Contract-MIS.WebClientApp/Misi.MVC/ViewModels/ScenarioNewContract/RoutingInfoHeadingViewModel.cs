using System;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class RoutingInfoHeadingViewModel
    {
        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof (SharedResource))]
        public string IdrWebNumber { get; set; }

        [LocalizedDisplayName("QuotationNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public int QuotationNumber { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (SharedResource))]
        public ContractNumberViewModel ContractNumberViewModel { get; set; }

        public PredefinedScenarioViewModel PredefinedScenarioViewModel { get; set; }
        public SoftwareTypeViewModel SoftwareTypeViewModel { get; set; }

        [LocalizedDisplayName("Equipment", NameResourceType = typeof (ScenarioNewContractResource))]
        public int Equipment { get; set; }

        [LocalizedDisplayName("EquipmentDescription", NameResourceType = typeof (SharedResource))]
        public string EquipmentDescription { get; set; }

        [LocalizedDisplayName("Device", NameResourceType = typeof (SharedResource))]
        public string Device { get; set; }

        [LocalizedDisplayName("SnDevice", NameResourceType = typeof (SharedResource))]
        public string SnDevice { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (SharedResource))]
        public string RoutingMemo { get; set; }

        [LocalizedDisplayName("ScenarioType", NameResourceType = typeof (ScenarioNewContractResource))]
        public string ScenarioType { get; set; }

        [LocalizedDisplayName("ContractLineNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public string ContractLineNumber { get; set; }

        
    }
}