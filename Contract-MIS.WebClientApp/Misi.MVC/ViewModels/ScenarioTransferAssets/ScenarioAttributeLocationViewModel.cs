using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class ScenarioAttributeLocationViewModel : BaseScenarioAttributeViewModel
    {
        [Required]
        [LocalizedDisplayName("UserHolderName", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        //public string UserHolderName { get; set; }
        public IEnumerable<SelectListItem> UserHolderNameList { get; set; }

        [Required]
        [LocalizedDisplayName("UserSalaryNumber", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        //public string UserSalaryNumber { get; set; }
        public IEnumerable<SelectListItem> UserSalaryNumberList { get; set; }

        [Required]
        [LocalizedDisplayName("OldLocation", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        //public string OldLocation { get; set; }
        public IEnumerable<SelectListItem> OldLocationList { get; set; }

        [RequiredIfInRoles("Asset Admin")]
        [LocalizedDisplayName("NewLocation", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        //public string NewLocation { get; set; }
        public DropDownListViewModel NewLocationList { get; set; }
    }
}