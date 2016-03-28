using System.Collections.Generic;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class ReportInvoiceDetailLineViewModel
    {

        public string MaterialCategoryName { get; set; }
        public string Qty { get; set; } 
        public string TotalCharges { get; set; } 
        public IEnumerable<MaterialSubCategoryLineViewModel> MaterialSubCategoryLineViewModels { get; set; } 
         
    }
}