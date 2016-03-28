using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioBroken
{
    public class RoutingInfoViewModel : BaseRoutingInfoViewModel
    {
        [LocalizedDisplayName("BackupEquipmentNumber", NameResourceType = typeof (Resources.ScenarioBrokenResource))]
        public string BackupEquipmentNumber { get; set; }
    }
}