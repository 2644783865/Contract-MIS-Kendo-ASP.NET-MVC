using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class RoutingInfoViewModel
    {
        public RoutingInfoHeadingViewModel RoutingInfoHeadingViewModel { get; set; }

        public RoutingTableViewModel RoutingTableViewModel { get; set; }
        public PreviewRequestInfoViewModel PreviewRequestInfoViewModel { get; set; }
    }
}