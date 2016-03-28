using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    public class ContractNumberViewModel
    {
        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractNumber { get; set; }
        
        [LocalizedDisplayName("ContractLineNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string ContractLineNumber { get; set; }
    }
}