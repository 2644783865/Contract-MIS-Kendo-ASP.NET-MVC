using System;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class PreviewRequestInfoSubTableViewModel
    {
        [LocalizedDisplayName("SubItem", NameResourceType = typeof (SharedResource))]
        public string SubItem { get; set; }

        [LocalizedDisplayName("RoutingCreation", NameResourceType = typeof (SharedResource))]
        public DateTime RoutingCreation { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof (SharedResource))]
        public string IdrWebNumber { get; set; }

        [LocalizedDisplayName("QuotationNumber", NameResourceType = typeof (SharedResource))]
        public int QuotationNumber { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof(SharedResource))]
        public int ContractNumber { get; set; }
        
        [LocalizedDisplayName("PredefinedScenario", NameResourceType = typeof (SharedResource))]
        public string PredefinedScenario { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (SharedResource))]
        public string RoutingMemo { get; set; }

        [LocalizedDisplayName("DivisionStatus", NameResourceType = typeof (SharedResource))]

        public string DivisionStatus { get; set; }

        [LocalizedDisplayName("SaStatus", NameResourceType = typeof (SharedResource))]
        public string SaStatus { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (SharedResource))]

        public string RoutingStatus { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof (SharedResource))]
        public string ReasonForRejection { get; set; }
        
    }
}