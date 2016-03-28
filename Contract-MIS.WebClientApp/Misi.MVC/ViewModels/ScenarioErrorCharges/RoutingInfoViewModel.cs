using System.Linq;
using System.Web;
using Misi.MVC.ViewModels.ScenarioGeneral;


namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class RoutingInfoViewModel
    {
        public RoutingInfoHeadingViewModel RoutingInfoHeadingViewModel { get; set; }
        public RoutingInfoMidViewModel RoutingInfoMidViewModel { get; set; }
        public RoutingInfoWorkflowViewModel RoutingInfoWorkflowViewModel { get; set; }
    }
}