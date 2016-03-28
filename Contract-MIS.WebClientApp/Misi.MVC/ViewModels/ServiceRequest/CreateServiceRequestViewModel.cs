using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ServiceRequest
{
    public class CreateServiceRequestViewModel
    {
        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("Scenario", NameResourceType = typeof(SharedResource))]
        public DropDownListViewModel Scenarios { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (SharedResource))]
        public DropDownListViewModel IssuedByListItems { get; set; }

        [RequiredIfInRoles("Admin", "Dewa")]
        [LocalizedDisplayName("ServiceId", NameResourceType = typeof (SharedResource))]
        public string ServiceId { get; set; }

        /// <summary>
        /// Ini akan jadi Ticket ID, Notification ID, atau Referensi yang lain
        /// </summary>
        [LocalizedDisplayName("ReferenceId", NameResourceType = typeof (ServiceRequestResource))]
        public string ReferenceId { get; set; }

        [LocalizedDisplayName("NotificationId", NameResourceType = typeof(ServiceRequestResource))]
        public string NotificationId { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("TicketId", NameResourceType = typeof (ServiceRequestResource))]
        public string TicketId { get; set; }
    }
}