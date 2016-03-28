using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class RoutingInfoWorkflowTableViewModel
    {
        [LocalizedDisplayName("Status", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public string Status { get; set; }

        [LocalizedDisplayName("SalesAdmin", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public bool SalesAdmin { get; set; }

        [LocalizedDisplayName("AccountManager", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public bool AccountManager { get; set; }

        [LocalizedDisplayName("Billing", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public bool Billing { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public DropDownListViewModel RoutingStatusListItems { get; set; }
    }
}