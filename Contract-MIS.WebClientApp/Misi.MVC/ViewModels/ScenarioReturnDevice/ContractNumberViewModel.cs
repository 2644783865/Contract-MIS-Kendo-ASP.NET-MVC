using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioReturnDevice
{
    /// <summary>
    /// ContractNumberViewModel for Scenario Return Device
    /// </summary>
    public class ContractNumberViewModel
    {
        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string ContractNumber { get; set; }

        [LocalizedDisplayName("ContractLineNumber", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> ContractLineNumber { get; set; }
    }
}