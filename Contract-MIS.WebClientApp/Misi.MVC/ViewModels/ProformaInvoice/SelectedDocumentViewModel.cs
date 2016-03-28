using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    public class SelectedDocumentViewModel
    {
        
        [LocalizedDisplayName("IsActiveDocumentSelected", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public bool ? IsActiveDocumentSelected { get; set; }

        [LocalizedDisplayName("IsBlockedDocumentSelected", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public bool ? IsBlockedDocumentSelected { get; set; }

    }
}