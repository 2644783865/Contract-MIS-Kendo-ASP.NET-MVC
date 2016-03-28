using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioNew
{
    public class RoutingInfoHeadingViewModel : BaseRoutingInfoHeadingViewModel
    {
        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof(Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [Required]
        public ContractNumberViewModel ContractNumberViewModel { get; set; }

        [Required]
        public PredefinedScenarioViewModel PredefinedScenarioViewModel { get; set; }

        public EquipmentViewModel EquipmentViewModel { get; set; }

        [LocalizedDisplayName("Device", NameResourceType = typeof(Resources.SharedResource))]
        public IEnumerable<SelectListItem> DeviceList { get; set; }

        [LocalizedDisplayName("SnDevice", NameResourceType = typeof (Resources.SharedResource))]
        public string SnDevice { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof(Resources.SharedResource))]
        public string RoutingMemo { get; set; }
    }
}