using System;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class RoutingInfoMidTableViewModel
    {
        [LocalizedDisplayName("Description", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public string Description { get; set; }

        [LocalizedDisplayName("Month", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public DateTime Month { get; set; }

        [LocalizedDisplayName("Deduction", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public int Deduction { get; set; }

        [LocalizedDisplayName("Currency", NameResourceType = typeof (ScenarioErrorChargesResource))]
        public string Currency { get; set; }
    }
}