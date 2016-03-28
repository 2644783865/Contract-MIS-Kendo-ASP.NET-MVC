using System;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    public enum SelectedDocuments
    {
        Active = 1,
        Blocked = 2
    }

    public class MainProformaInvoiceViewModel
    {
        [LocalizedDisplayName("BillingDateFrom", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public DateTime BillingDateFrom { get; set; }

        [LocalizedDisplayName("BillingType", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string BillingType { get; set; }

        [LocalizedDisplayName("BillingDateTo", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public DateTime BillingDateTo { get; set; }

        [LocalizedDisplayName("BillingType", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public KendoDropDownListViewModel BillingTypeList{ get; set; }

        [LocalizedDisplayName("BillingRun", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public KendoDropDownListViewModel BillingRun { get; set; }

        [LocalizedDisplayName("SoldToPartyFrom", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public KendoDropDownListViewModel SoldToPartyFrom { get; set; }

        [LocalizedDisplayName("SoldToPartyTo", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public KendoDropDownListViewModel SoldToPartyTo { get; set; }

        [LocalizedDisplayName("SelectedDocument", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public SelectedDocumentViewModel SelectedDocuments { get; set; }

        public RadioButtonWithListViewModel PopupBillingDocumentViewModel { get; set; }

        public string DateFromValue { get; set; }

        public string DateToValue { get; set; }

        public string SoldToFromValue { get; set; }

        public bool IsActiveDocSelectedValue { get; set; }

        public bool IsBlockedDocSelectedValue { get; set; }

    }
}