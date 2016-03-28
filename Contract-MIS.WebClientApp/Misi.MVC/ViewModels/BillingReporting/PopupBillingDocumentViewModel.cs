using System;
using System.Collections.Generic;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class PopupBillingDocumentViewModel
    {
        public MSTInvoiceBillingReportingViewModel MSTModel { get; set; }

        public RadioButtonWithListViewModel Lines { get; set; }

        public string HeaderTitle { get; set; }

        public string DateFromValue { get; set; }

        public string SoldToPartyValue { get; set; }
        public string DateToValue { get; set; }

    }
}