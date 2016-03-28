using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class RequestInfoHeadingViewModel
    {
        [LocalizedDisplayName("ServiceId", NameResourceType = typeof (SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (SharedResource))]
        public string Scenario { get; set; }

        [LocalizedDisplayName("ScenarioType", NameResourceType = typeof (ScenarioTerminationResource))]
        public IEnumerable<SelectListItem> DetailScenariosListItems { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> IssuedByListItems { get; set; }

        [LocalizedDisplayName("IssuedDate", NameResourceType = typeof (SharedResource))]
        public DateTime IssuedDate { get; set; }

        [LocalizedDisplayName("RequestedVia", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> RequestedViaListItems { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof (SharedResource))]
        public string RequestMemo { get; set; }

        [LocalizedDisplayName("File", NameResourceType = typeof (Resources.SharedResource))]
        public FileUploadViewModel FileUpload { get; set; }

        public IEnumerable<TerminationRequestInfoLineViewModel> TerminationRequestInfoLineViewModels { get; set; }
    }
}