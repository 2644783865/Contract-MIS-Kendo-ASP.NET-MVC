using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioBroken
{
    public class RequestInfoHeadingViewModel : BaseRequestInfoViewModel
    {
        [LocalizedDisplayName("ServiceId", NameResourceType = typeof (Resources.SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("RequestedBy", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestedBy { get; set; }

        [LocalizedDisplayName("SnOrIdNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string SnOrIdNumber { get; set; }

        [LocalizedDisplayName("CustomerId", NameResourceType = typeof (Resources.SharedResource))]
        public string CustomerId { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (Resources.SharedResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("Branch", NameResourceType = typeof (Resources.ScenarioBrokenResource))]
        public string Branch { get; set; }

        [LocalizedDisplayName("NotificationId", NameResourceType = typeof (Resources.SharedResource))]
        public string NotificationId { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> IssuedByList { get; set; }

        [LocalizedDisplayName("NotificationDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime NotificationDate { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestMemo { get; set; }
    }
}