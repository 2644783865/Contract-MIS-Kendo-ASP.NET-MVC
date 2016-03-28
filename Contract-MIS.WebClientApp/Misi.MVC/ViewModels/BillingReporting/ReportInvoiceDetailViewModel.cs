using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class ReportInvoiceDetailViewModel
    {
        
        //properti header
        public string Name1 { get; set; }
        public string Tdline { get; set; }
        public string InvoiceNo { get; set; } 
        public string TotalCharges { get; set; } 
        public string Discount { get; set; } 
        public string Deduction { get; set; }
        public string TotatalChargesAfterDiscount { get; set; }
        
        public string Currency { get; set; }
        
        public IEnumerable<ReportInvoiceDetailLineViewModel> ReportInvoiceDetailLineViewModelList { get; set; } 


    }


}