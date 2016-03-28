using System.Security.AccessControl;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class RoutingInfoLdpViewModel
    {
        public RoutingInfoHeadingViewModel RoutingInfoHeadingViewModel { get; set; }
        public ScenarioAttributeViewModel ScenarioAttributeViewModel { get; set; }
        public RoutingTableViewModel RoutingTableViewModel { get; set; }
    }
}