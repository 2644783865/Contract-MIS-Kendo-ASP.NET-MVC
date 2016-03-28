using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class ScenarioAttributeHolderViewModel : BaseScenarioAttributeViewModel
    {
        [Required]
        [LocalizedDisplayName("OldHolderName", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string OldHolderName { get; set; }

        [Required]
        [LocalizedDisplayName("OldSalaryNumber", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string OldSalaryNumber { get; set; }

        [Required]
        [LocalizedDisplayName("OldLocation", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string OldLocation { get; set; }

        [Required]
        public NewContractNumberViewModel NewContractNumberViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("ReturnDeliveryOrder",NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string ReturnDeliveryOrder { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("NewHolderName", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string NewHolderName { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("NewSalaryNumber", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string NewSalaryNumber { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("NewLocation", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string NewLocation { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("SoDeliveryNumber", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string SoDeliveryNumber { get; set; }

        [RequiredIfInRoles("SCM-Delivery")]
        [LocalizedDisplayName("DeliveryOrderToUser",
            NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string DeliveryOrderToUser { get; set; }
    }
}