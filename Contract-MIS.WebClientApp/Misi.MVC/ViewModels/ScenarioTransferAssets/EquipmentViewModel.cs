using System.ComponentModel.DataAnnotations;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class EquipmentViewModel
    {
        public string Equipment { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("EquipmentDescription",NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string EquipmentDescription { get; set; }
    }
}