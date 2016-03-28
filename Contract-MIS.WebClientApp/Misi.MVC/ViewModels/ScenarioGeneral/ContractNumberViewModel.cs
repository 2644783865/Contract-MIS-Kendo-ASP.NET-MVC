using System.Collections.Generic;
using System.Web.WebPages.Html;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class ContractNumberViewModel
    {
        public IEnumerable<SelectListItem> ContractNumber { get; set; }

        [LocalizedDisplayName("ContracLineNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractLineNumber { get; set; }
    }
}