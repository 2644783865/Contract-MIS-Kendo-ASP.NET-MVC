using System;
using System.Collections.Generic;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class PreviewRequestInfoTableLineViewModel
    {
        [LocalizedDisplayName("SubItem", NameResourceType = typeof (SharedResource))]
        public string SubItem { get; set; }

        [LocalizedDisplayName("RoutingCreatinDate", NameResourceType = typeof (SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (SharedResource))]
        public string Scenario { get; set; }

        [LocalizedDisplayName("DetailScenario", NameResourceType = typeof (SharedResource))]
        public string DetailScenario { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (SharedResource))]
        public string RoutingMemo { get; set; }

        [LocalizedDisplayName("DivisionStatus", NameResourceType = typeof (SharedResource))]
        public string DivisionStatus { get; set; }

        [LocalizedDisplayName("SaStatus", NameResourceType = typeof (SharedResource))]
        public string SaStatus { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (SharedResource))]
        public string RoutingStatus { get; set; }
        
    }
}