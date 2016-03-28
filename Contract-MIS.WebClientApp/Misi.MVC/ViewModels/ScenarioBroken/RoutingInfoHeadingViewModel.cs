using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioBroken
{
    public class RoutingInfoHeadingViewModel : BaseRoutingInfoViewModel
    {
        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof(Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [Required]
        public ContractNumberViewModel ContractNumberViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("PredefinedScenario", NameResourceType = typeof (Resources.SharedResource))]
        public DropDownListViewModel PredefinedScenarioList { get; set; }

        [Required]
        public EquipmentViewModel EquipmentViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("Device", NameResourceType = typeof(Resources.SharedResource))]
        public DropDownListViewModel DeviceList { get; set; }

        [Required]
        [LocalizedDisplayName("SnDevice", NameResourceType = typeof (Resources.SharedResource))]
        public string SnDevice { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof(Resources.SharedResource))]
        public string RoutingMemo { get; set; }
    }
}