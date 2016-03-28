using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class SoftwareTypeViewModel
    {
        [LocalizedDisplayName("SoftwareType", NameResourceType = typeof (Resources.ScenarioNewContractResource))]
        public IEnumerable<SelectListItem> SoftwareListItems { get; set; }
    }
}