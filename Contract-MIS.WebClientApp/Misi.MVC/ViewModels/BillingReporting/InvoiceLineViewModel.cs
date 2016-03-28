using System.Collections;
using System.Collections.Generic;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class InvoiceLineViewModel 
    {
        public string Description { get; set; }
        public string Amount { get; set; }


        public IEnumerable<ClasClasan> okasokas { get; set; } 
    }

    public class ClasClasan
    {
        public string blabla { get; set; }
    }
}