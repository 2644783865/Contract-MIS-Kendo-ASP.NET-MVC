using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class BaseRoutingInfoHeadingViewModel
    {
        [RequiredIfInRoles("Billing System")]
        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (SharedResource))]
        public string Scenario { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("DetailScenario", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> DetailScenarioListItems { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (SharedResource))]
        public string RoutingMemo { get; set; }
    }
}