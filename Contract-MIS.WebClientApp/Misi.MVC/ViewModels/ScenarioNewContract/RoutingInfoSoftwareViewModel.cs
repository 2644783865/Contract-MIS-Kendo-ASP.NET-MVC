using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class RoutingInfoSoftwareViewModel
    {
        public RoutingInfoHeadingViewModel RoutingInfoHeadingViewModel { get; set; }
        public ScenarioAttributeViewModel ScenarioAttributeSoftwareViewModel { get; set; }
        public RoutingTableViewModel RoutingTableViewModel { get; set; }
    }
}