using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioReturnDevice
{
    /// <summary>
    /// EquipmentViewModel for Scenario Return Device
    /// </summary>
    public class EquipmentViewModel
    {
        [LocalizedDisplayName("Equipment", NameResourceType = typeof (Resources.SharedResource))]
        public string Equipment { get; set; }

        [LocalizedDisplayName("EquipmentDescription", NameResourceType = typeof (Resources.SharedResource))]
        public string EquipmentDescription { get; set; }
    }
}