using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class RequestInfoHeadingViewModel
    {
        [LocalizedDisplayName("ServiceId", NameResourceType = typeof (SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("RequestedBy", NameResourceType = typeof (SharedResource))]
        public string RequestedBy { get; set; }

        [LocalizedDisplayName("SnOrIdNumber", NameResourceType = typeof (SharedResource))]
        public int SnOrIdNumber { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (SharedResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("Location", NameResourceType = typeof (SharedResource))]
        public string Location { get; set; }

        [LocalizedDisplayName("Email", NameResourceType = typeof (SharedResource))]
        public string Email { get; set; }

        [LocalizedDisplayName("RequestedDate", NameResourceType = typeof (SharedResource))]
        public DateTime RequestedDate { get; set; }

        [LocalizedDisplayName("RequestedVia", NameResourceType = typeof (SharedResource))]
        public string RequestedVia { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof (SharedResource))]
        public string RequestMemo { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> IssuedByListItems { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> IssuedByList { get; set; }

        [LocalizedDisplayName("IssuedDate", NameResourceType = typeof (SharedResource))]
        public DateTime IssuedDate { get; set; }
    }
}