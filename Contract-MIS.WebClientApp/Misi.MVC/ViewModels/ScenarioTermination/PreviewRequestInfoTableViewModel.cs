using System;
using System.Collections.Generic;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class PreviewRequestInfoTableViewModel
    {
        [LocalizedDisplayName("Item", NameResourceType = typeof(Resources.SharedResource))]
        public int Item { get; set; }

        [LocalizedDisplayName("ServiceId", NameResourceType = typeof(Resources.SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof(Resources.SharedResource))]
        public string Scenario { get; set; }

        [LocalizedDisplayName("DetailScenario", NameResourceType = typeof(Resources.ScenarioTerminationResource))]
        public string DetailScenario { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof(Resources.SharedResource))]
        public string IssuedBy { get; set; }

        [LocalizedDisplayName("IssuedDate", NameResourceType = typeof(Resources.SharedResource))]
        public DateTime IssuedDate { get; set; }

        [LocalizedDisplayName("RequestedVia", NameResourceType = typeof(Resources.SharedResource))]
        public string RequestedVia { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof(Resources.SharedResource))]
        public string RequestMemo { get; set; }

        [LocalizedDisplayName("Modify", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Modify { get; set; }
    }
}