using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;


namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class ContractNumberViewModel
    {
        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractNumber { get; set; }
        
        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("ContractLineNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractLineNumber { get; set; }
    }
}