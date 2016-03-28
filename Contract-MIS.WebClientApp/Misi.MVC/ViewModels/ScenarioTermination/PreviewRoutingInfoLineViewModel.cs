using System;
using System.Collections.Generic;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class PreviewRoutingInfoLineViewModel
    {
        [LocalizedDisplayName("SubItem", NameResourceType = typeof (Resources.SharedResource))]
        public int SubItem { get; set; }

        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractNumber { get; set; }

        [LocalizedDisplayName("PredefinedScenario", NameResourceType = typeof (Resources.SharedResource))]
        public string PredefinedScenario { get; set; }

        [LocalizedDisplayName("PredefinedScenarioType", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<PreviewServiceLineTable> PreviewServiceLineTables { get; set; }
    }
}