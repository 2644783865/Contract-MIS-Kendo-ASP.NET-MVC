using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class HeaderInoviceDetailViewModel
    {
        public string PayerName { get; set; }
        public string Currency { get; set; }
        public string InvoiceNo { get; set; }
        public string HeaderNote { get; set; } 
        
    }
}