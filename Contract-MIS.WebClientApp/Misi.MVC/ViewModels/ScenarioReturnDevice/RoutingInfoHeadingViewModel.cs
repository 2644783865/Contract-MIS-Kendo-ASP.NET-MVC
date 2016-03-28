using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioReturnDevice
{
    public class RoutingInfoHeadingViewModel : BaseRoutingInfoHeadingViewModel
    {
        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [Required]
        public ContractNumberViewModel ContractNumberViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("PredefinedScenario", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> PredefinedScenarioList { get; set; }

        [Required]
        public EquipmentViewModel EquipmentViewModel { get; set; }

        [Required]
        public DeviceViewModel DeviceViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("SnDevice", NameResourceType = typeof(Resources.SharedResource))]
        public string SnDevice { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof(Resources.SharedResource))]
        public string RoutingMemo { get; set; }

    }
}