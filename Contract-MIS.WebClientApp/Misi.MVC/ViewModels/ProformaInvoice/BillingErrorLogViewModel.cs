using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    public class BillingErrorLogViewModel
    {
        [LocalizedDisplayName("Group", NameResourceType = typeof (Resources.SharedResource))]
        public string Group { get; set; }

        [LocalizedDisplayName("SDDocument", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string SDDocument { get; set; }

        [LocalizedDisplayName("SDDocumentLineItem", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string SDDocumentLineItem { get; set; }

        [LocalizedDisplayName("Description", NameResourceType = typeof (Resources.SharedResource))]
        public string Description { get; set; }

        [LocalizedDisplayName("Status", NameResourceType = typeof (Resources.SharedResource))]
        public bool Status { get; set; }
    }
}