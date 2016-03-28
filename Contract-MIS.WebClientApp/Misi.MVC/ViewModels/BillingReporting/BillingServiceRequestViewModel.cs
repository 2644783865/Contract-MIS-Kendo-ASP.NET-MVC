using System;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class BillingServiceRequestViewModel
    {
        [LocalizedDisplayName("IssuedDateFrom", NameResourceType = typeof(Resources.BillingReportingResource))]
        public DateTime IssuedDateFrom { get; set; }

        [LocalizedDisplayName("IssuedDateTo", NameResourceType = typeof(Resources.BillingReportingResource))]
        public DateTime IssuedDateTo { get; set; }

        [LocalizedDisplayName("ScenarioCheckList", NameResourceType = typeof(Resources.BillingReportingResource))]
        public ScenarioCheckListViewModel ScenarioCheckList { get; set; }
    }
}