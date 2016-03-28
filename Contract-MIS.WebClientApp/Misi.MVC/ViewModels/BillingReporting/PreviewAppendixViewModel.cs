using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class PreviewAppendixViewModel
    {
        public IEnumerable<AppendixTableViewModel> AppendixTableViewModels { get; set; }

        public string bilDoc { get; set; }
        
    }
}