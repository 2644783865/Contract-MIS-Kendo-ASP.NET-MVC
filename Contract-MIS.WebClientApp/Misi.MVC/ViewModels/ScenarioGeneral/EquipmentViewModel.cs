using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class EquipmentViewModel
    {
        public string Equipment { get; set; }

        [LocalizedDisplayName("EquipmentDescription", NameResourceType = typeof (Resources.SharedResource))]
        public string EquipmentDescription { get; set; }
    }
}