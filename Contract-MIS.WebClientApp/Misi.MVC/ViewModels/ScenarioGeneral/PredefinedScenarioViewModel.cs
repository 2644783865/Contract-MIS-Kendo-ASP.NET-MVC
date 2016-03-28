using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class PredefinedScenarioViewModel
    {
        [LocalizedDisplayName("PredefinedScenario", NameResourceType = typeof (ScenarioNewContractResource))]
        public IEnumerable<SelectListItem> PredefinedScenario { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("SubPredefinedScenario", NameResourceType = typeof (ScenarioNewContractResource))]
        public IEnumerable<SelectListItem> SubPredefinedScenarioList { get; set; }
    }
}