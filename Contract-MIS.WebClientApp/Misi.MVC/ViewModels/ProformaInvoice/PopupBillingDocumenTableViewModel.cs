using System;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    public class PopupBillingDocumenLineViewModel
    {
        public string BillingdocNumber { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}