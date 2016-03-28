using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    public class PopupBillingDocumentViewModel
    {
        public bool IsBlockedDocSelectedValue { get; set; }

        public bool IsActiveDocSelectedValue { get; set; }

        public RadioButtonWithListViewModel Lines { get; set; }

        public string HeaderTitle { get; set; }
    }
}