using Misi.MVC.ViewModels.ScenarioBroken;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioReturnDevice
{
    public class RoutingInfoReturnDeviceViewModel
    {
        public RoutingInfoHeadingViewModel RoutingInfoHeadingViewModel { get; set; }
        public ScenarioAttributeReturnDeviceViewModel ScenarioAttributeReturnDeviceViewModel { get; set; }
        public RoutingTableViewModel RoutingTableViewModel { get; set; }
    }
}