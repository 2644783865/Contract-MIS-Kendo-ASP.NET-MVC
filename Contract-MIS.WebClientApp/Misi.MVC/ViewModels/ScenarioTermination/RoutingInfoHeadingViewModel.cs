using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class RoutingInfoHeadingViewModel
    {
        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> Scenario { get; set; }

        [LocalizedDisplayName("ScenarioType", NameResourceType = typeof (ScenarioTerminationResource))]
        public IEnumerable<SelectListItem> DetailScenarioListItems { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (SharedResource))]
        public string RoutingMemo { get; set; }

        public IEnumerable<TerminationRoutingInfoLineViewModel> TerminationRoutingInfoLineViewModels { get; set; }
    }
}