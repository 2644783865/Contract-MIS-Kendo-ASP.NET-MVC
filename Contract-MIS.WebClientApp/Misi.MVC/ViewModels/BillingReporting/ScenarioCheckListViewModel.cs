using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class ScenarioCheckListViewModel
    {
        [LocalizedDisplayName("IncorrectExternalData", NameResourceType = typeof(Resources.BillingReportingResource))]
        public bool IncorrectExternalData { get; set; }

        [LocalizedDisplayName("Termination", NameResourceType = typeof(Resources.BillingReportingResource))]
        public bool Termination { get; set; }

        [LocalizedDisplayName("ReturnDevice", NameResourceType = typeof(Resources.BillingReportingResource))]
        public bool ReturnDevice { get; set; }
    }
}