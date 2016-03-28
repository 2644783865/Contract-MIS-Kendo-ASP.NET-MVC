using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class InvoiceTypeViewModel
    {
        [LocalizedDisplayName("IsInvoiceSelected", NameResourceType = typeof(Resources.BillingReportingResource))]
        public bool IsInvoiceSelected { get; set; }

        [LocalizedDisplayName("IsInvoiceDetailSelected", NameResourceType = typeof(Resources.BillingReportingResource))]
        public bool IsInvoiceDetailSelected { get; set; }

        [LocalizedDisplayName("IsAppendixSelected", NameResourceType = typeof(Resources.BillingReportingResource))]
        public bool IsAppendixSelected { get; set; }
    }
}