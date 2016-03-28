using System;
using System.Collections.Generic;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioBroken
{
    public class PreviewRequestInfoViewModel
    {
        [LocalizedDisplayName("Item", NameResourceType = typeof(Resources.SharedResource))]
        public int Item { get; set; }

        [LocalizedDisplayName("ServiceId", NameResourceType = typeof(Resources.SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("NotificationId", NameResourceType = typeof(Resources.SharedResource))]
        public string NotificationId { get; set; }

        [LocalizedDisplayName("RequestedBy", NameResourceType = typeof(Resources.SharedResource))]
        public string RequestBy { get; set; }

        [LocalizedDisplayName("SnOrIdNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string SnOrIdNumber { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof(Resources.SharedResource))]
        public string IssuedBy { get; set; }

        [LocalizedDisplayName("NotificationDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime NotificationDate { get; set; }

        [LocalizedDisplayName("CustomerId", NameResourceType = typeof (Resources.SharedResource))]
        public string CustomerId { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof(Resources.SharedResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("Branch", NameResourceType = typeof (Resources.SharedResource))]
        public string Branch { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof(Resources.SharedResource))]
        public string RequestMemo { get; set; }

        public IEnumerable<PreviewRoutingInfoLineViewModel> PreviewRoutingInfoLineViewModels { get; set; }
        
    }
}