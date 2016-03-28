using System;
using System.Collections.Generic;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class RoutingInfoHeadingViewModel
    {
        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (SharedResource))]
        public string RoutingMemo { get; set; }

        [LocalizedDisplayName("SoldToParty", NameResourceType = typeof (SharedResource))]
        public string SoldToParty { get; set; }

        public IEnumerable<RoutingInfoTableLineViewModel> RoutingInfoTableLineViewModel { get; set; }
    }
}