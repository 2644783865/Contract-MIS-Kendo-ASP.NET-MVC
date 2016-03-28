using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class RequestInfoHeadingViewModel : BaseRequestInfoViewModel
    {
        [RequiredIfInRoles("Billing System")]
        [LocalizedDisplayName("ServiceId", NameResourceType = typeof (Resources.SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("RequestedBy", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestedBy { get; set; }

        [LocalizedDisplayName("SnOrIdNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string SnOrIdNumber { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (Resources.SharedResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("Location", NameResourceType = typeof (Resources.SharedResource))]
        public string Location { get; set; }

        [LocalizedDisplayName("Email", NameResourceType = typeof (Resources.SharedResource))]
        public string Email { get; set; }

        [LocalizedDisplayName("RequestedDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RequestedDate { get; set; }

        [LocalizedDisplayName("TicketCategory", NameResourceType = typeof (Resources.SharedResource))]
        public TicketCategoryViewModel TicketCategoryViewModel { get; set; }

        [LocalizedDisplayName("RequestedVia", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestedVia { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestMemo { get; set; }

        [LocalizedDisplayName("TicketId", NameResourceType = typeof (Resources.SharedResource))]
        public string TicketId { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (Resources.SharedResource))]
        public string IssuedBy { get; set; }

        [LocalizedDisplayName("IssuedDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime IssuedDate { get; set; }
    }
}