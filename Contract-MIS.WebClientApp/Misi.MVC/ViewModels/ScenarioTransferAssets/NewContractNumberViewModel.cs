using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class NewContractNumberViewModel
    {
        [LocalizedDisplayName("NewContractNumber", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string NewContractNumber { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("NewContractLineNumber", NameResourceType = typeof(Resources.ScenarioTransferAssetsResource))]
        public string NewContractLineNumber { get; set; }
    }
}