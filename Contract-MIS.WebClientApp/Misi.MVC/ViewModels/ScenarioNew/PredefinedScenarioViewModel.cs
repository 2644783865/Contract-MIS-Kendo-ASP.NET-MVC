using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioNew
{
    public class PredefinedScenarioViewModel
    {
        
        [LocalizedDisplayName("PredefinedScenario", NameResourceType = typeof (Resources.SharedResource))]
        public DropDownListViewModel PredefinedScenarioList { get; set; }

        [Required]
        [LocalizedDisplayName("NewNameScenario", NameResourceType = typeof(Resources.SharedResource))]
        public string NewNameScenario { get; set; }
    }
}