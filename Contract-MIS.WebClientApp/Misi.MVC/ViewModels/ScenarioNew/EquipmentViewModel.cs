using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioNew
{
    public class EquipmentViewModel
    {
        [LocalizedDisplayName("Equipment", NameResourceType = typeof (Resources.ScenarioNewResource))]
        public string Equipment { get; set; }

        [LocalizedDisplayName("EquipmentDescription", NameResourceType = typeof (Resources.ScenarioNewResource))]
        public string EquipmentDescription { get; set; }
    }
}