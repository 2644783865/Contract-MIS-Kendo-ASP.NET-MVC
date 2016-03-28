using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class RoutingInfoHeadingViewModel : BaseRoutingInfoHeadingViewModel
    {
        //[LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (Resources.SharedResources))]
        //public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        public ContractNumberViewModel ContractNumberViewModel { get; set; }

        [Required]
        public PredefinedScenarioViewModel PredefinedScenarioViewModel { get; set; }

        [Required]
        public EquipmentViewModel EquipmentViewModel { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("Device", NameResourceType = typeof (Resources.SharedResource))]
        public DropDownListViewModel DeviceList { get; set; }

        [RequiredIfInRoles("Sales Admin")]
        [LocalizedDisplayName("SnDevice", NameResourceType = typeof (Resources.SharedResource))]
        public string SnDevice { get; set; }

        //[LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (Resources.SharedResources))]
        //public string RoutingMemo { get; set; }

        [LocalizedDisplayName("ScenarioType", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string ScenarioType { get; set; }

       
    }
}