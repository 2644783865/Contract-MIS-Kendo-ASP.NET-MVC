using System.Collections.Generic;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class RoutingTableViewModel
    {
        public IEnumerable<RoutingTableLineViewModel> RoutingTableLineViewModels { get; set; }
    }
}