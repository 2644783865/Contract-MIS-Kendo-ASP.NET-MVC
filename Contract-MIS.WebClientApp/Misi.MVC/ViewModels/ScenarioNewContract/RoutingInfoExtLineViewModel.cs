using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Misi.MVC.ViewModels.ScenarioGeneral;


namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class RoutingInfoExtLineViewModel
    {
        public RoutingInfoHeadingViewModel RoutingInfoHeadingViewModel { get; set; }
        public ScenarioAttributeViewModel ScenarioAttributeExtLineViewModel { get; set; }
        public RoutingTableViewModel RoutingTableViewModel { get; set; }
    }
}