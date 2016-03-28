using Misi.MVC.Filters;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    public class RunProformaInvoiceHeaderViewModel
    { 
        [LocalizedDisplayName("BillingDateFrom", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string BillingDateFrom { get; set; }

        [LocalizedDisplayName("BillingDateTo", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string BillingDateTo { get; set; }

        [LocalizedDisplayName("BillingRun", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string BillingRun { get; set; }

        [LocalizedDisplayName("BillingType", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string BillingType { get; set; }

        [LocalizedDisplayName("SoldToParty", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string SoldToParty { get; set; }

        [LocalizedDisplayName("Version", NameResourceType = typeof(Resources.SharedResource))]
        public DropDownListViewModel Versions { get; set; }

        [LocalizedDisplayName("IsFinal", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public bool IsFinal { get; set; }

        [LocalizedDisplayName("CreatedBy", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string CreatedBy { get; set; }

        [LocalizedDisplayName("CreatedOn", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string CreatedOn { get; set; }

        [LocalizedDisplayName("Time", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string Time { get; set; }

        public int EstimatedProcessTime { get; set; }

        public int NumberOfRows { get; set; }

    }
}