using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Misi.MVC.Resources;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioNewContract
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
        public DropDownListViewModel CompanyListItems { get; set; }

        [LocalizedDisplayName("Location", NameResourceType = typeof (SharedResource))]
        public string Location { get; set; }

        [LocalizedDisplayName("RequestedDate", NameResourceType = typeof (SharedResource))]
        public DateTime RequestedDate { get; set; }

        [LocalizedDisplayName("RequestedVia", NameResourceType = typeof (SharedResource))]
        public DropDownListViewModel RequestedviaListItems { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof (SharedResource))]
        public string RequestMemo { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> IssuedByListItems { get; set; }

        [LocalizedDisplayName("IssuedDate", NameResourceType = typeof (SharedResource))]
        public DateTime IssuedDate { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (SharedResource))]
        public IEnumerable<SelectListItem> ScenarioListItems { get; set; }
    }
}