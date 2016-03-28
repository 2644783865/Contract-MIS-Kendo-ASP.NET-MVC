using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Misi.MVC.Filters;
using System;
using System.Web.WebPages.Html;
using Misi.MVC.ViewModels.ScenarioTransferAssets;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class BaseRoutingInfoViewModel
    {
        public BaseRoutingInfoHeadingViewModel BaseRoutingInfoHeadingViewModel { get; set; }

        public BaseScenarioAttributeViewModel BaseScreeningAttibuteViewModel { get; set; }

        public RoutingTableViewModel RoutingTableViewModel { get; set; }
    }


    public class BaseRoutingInfoViewModel1
    {
        #region Routing Information

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> ScenarioList { get; set; }

        [LocalizedDisplayName("RoutingCreatingDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [Required]
        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public ContractNumberViewModel ContractNumberViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("PredefinedScenario", NameResourceType = typeof (Resources.SharedResource))]
        public PredefinedScenarioViewModel PredefinedScenarioViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("Equipment", NameResourceType = typeof (Resources.SharedResource))]
        public EquipmentViewModel EquipmentViewModel { get; set; }

        [Required]
        [LocalizedDisplayName("Device", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> Devices { get; set; }

        [Required]
        [LocalizedDisplayName("SnDevice", NameResourceType = typeof (Resources.SharedResource))]
        public string SnDevice { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (Resources.SharedResource))]
        public string RoutingMemo { get; set; }

        #endregion

        #region ScenarioAtribute

        [Required]
        [LocalizedDisplayName("UserHolderName", NameResourceType = typeof (Resources.SharedResource))]
        public string UserHolderName { get; set; }

        [Required]
        [LocalizedDisplayName("UserSalaryNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string UserSalaryNumber { get; set; }

        [Required]
        [LocalizedDisplayName("NewLocation", NameResourceType = typeof (Resources.SharedResource))]
        public string NewLocation { get; set; }

        [LocalizedDisplayName("SoldToParty", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> SoldToPartyList { get; set; }

        #endregion
    }
}