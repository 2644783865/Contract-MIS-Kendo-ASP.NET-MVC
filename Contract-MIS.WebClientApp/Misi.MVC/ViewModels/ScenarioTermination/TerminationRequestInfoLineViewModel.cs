using System;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class TerminationRequestInfoLineViewModel
    {
        [LocalizedDisplayName("Item", NameResourceType = typeof (ScenarioTerminationResource))]
        public int Item { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("HolderName", NameResourceType = typeof (ScenarioTerminationResource))]
        public string HolderName { get; set; }

        [LocalizedDisplayName("SalaryNumber", NameResourceType = typeof (ScenarioTerminationResource))]
        public int SalaryNumber { get; set; }

        [LocalizedDisplayName("UserId", NameResourceType = typeof (ScenarioTerminationResource))]
        public string UserId { get; set; }

        [LocalizedDisplayName("Branch", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Branch { get; set; }

        [LocalizedDisplayName("Application", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Application { get; set; }

        [LocalizedDisplayName("RequestedDate", NameResourceType = typeof (ScenarioTerminationResource))]
        public DateTime RequestDate { get; set; }

        [LocalizedDisplayName("RequestedBy", NameResourceType = typeof (ScenarioTerminationResource))]
        public string RequestedBy { get; set; }

        [LocalizedDisplayName("ExtensionNumber", NameResourceType = typeof (ScenarioTerminationResource))]
        public int ExtensionNumber { get; set; }

        [LocalizedDisplayName("Status", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Status { get; set; }
    }
}