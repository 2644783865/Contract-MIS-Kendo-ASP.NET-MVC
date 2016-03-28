using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ServiceRequest
{
    public class MaintainServiceRequestViewModel
    {
        /// <summary>
        /// include property TicketId, ServiceId, IssuedDate from BaseRequestInfoViewModel,IssuedBy
        /// </summary>
        [LocalizedDisplayName("NotificationId", NameResourceType = typeof(Resources.SharedResource))]
        public string NotificationId { get; set; }

        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof(Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("BaselineCompletionDate", NameResourceType = typeof(Resources.SharedResource))]
        public DateTime BaselineCompletionDate { get; set; }

        [LocalizedDisplayName("PlanCompletionDate", NameResourceType = typeof(Resources.SharedResource))]
        public DateTime PlanCompletionDate { get; set; }

        [LocalizedDisplayName("ActualCompletionDate", NameResourceType = typeof(Resources.SharedResource))]
        public DateTime ActualCompletionDate { get; set; }

        [LocalizedDisplayName("SaStatus", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> SaStatusList { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> ReasonForRejection { get; set; }

        [LocalizedDisplayName("BlockingStatus", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> BlockingStatusList { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> RoutingStatusList { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> Scenarios { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> IssuedByListItems { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof(Resources.SharedResource))]
        public int ContractNumber { get; set; }

        [LocalizedDisplayName("ContractLineNumber", NameResourceType = typeof(Resources.SharedResource))]
        public int ContractLineNumber { get; set; }

        [LocalizedDisplayName("TicketId", NameResourceType = typeof (Resources.ServiceRequestResource))]
        public string TicketId { get; set; }

        [LocalizedDisplayName("ServiceId", NameResourceType = typeof(Resources.SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("IssuedDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime IssuedDate { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (Resources.ServiceRequestResource))]
        public IEnumerable<SelectListItem> RoutingStatus { get; set; }
    }
}