using System;
using System.Collections.Generic;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    /// <summary>
    /// Table level II: Warna Hijau
    /// </summary>
    public class BillingItemLineViewModel
    {
        [LocalizedDisplayName("ItemNumber", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public int ItemNumber { get; set; }

        [LocalizedDisplayName("ServiceId", NameResourceType = typeof (Resources.SharedResource))]
        public string ServiceId { get; set; }

        [LocalizedDisplayName("ReferenceId", NameResourceType = typeof (Resources.SharedResource))]
        public string ReferenceId { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (Resources.SharedResource))]
        public string Scenario { get; set; }

        [LocalizedDisplayName("RequestedBy", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestedBy { get; set; }

        [LocalizedDisplayName("IssuedBy", NameResourceType = typeof (Resources.SharedResource))]
        public string IssuedBy { get; set; }

        [LocalizedDisplayName("IssuedDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime IssuedDate { get; set; }

        [LocalizedDisplayName("SNorIDNumber", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string SNorIDNumber { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (Resources.SharedResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("Location", NameResourceType = typeof (Resources.SharedResource))]
        public string Location { get; set; }

        [LocalizedDisplayName("Email", NameResourceType = typeof (Resources.SharedResource))]
        public string Email { get; set; }

        [LocalizedDisplayName("RequestedDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RequestedDate { get; set; }

        [LocalizedDisplayName("RequestedVia", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestedVia { get; set; }

        [LocalizedDisplayName("RequestMemo", NameResourceType = typeof (Resources.SharedResource))]
        public string RequestMemo { get; set; }

        public IEnumerable<BillingSubItemLineViewModel> BillingSubItemLineViewModels { get; set; }
    }
}