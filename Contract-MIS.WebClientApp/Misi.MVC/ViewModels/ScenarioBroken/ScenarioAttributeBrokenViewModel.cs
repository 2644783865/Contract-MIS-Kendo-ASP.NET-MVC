using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioBroken
{
    public class ScenarioAttributeBrokenViewModel : BaseScenarioAttributeViewModel
    {
        [Required]
        [LocalizedDisplayName("UserHolderName", NameResourceType = typeof (Resources.SharedResource))]
        public DropDownListViewModel UserHolderNameList { get; set; }

        [Required]
        [LocalizedDisplayName("UserSalaryNumber", NameResourceType = typeof (Resources.SharedResource))]
        public DropDownListViewModel UserSalaryNumberList { get; set; }

        [Required]
        [LocalizedDisplayName("BackupEquipmentNumber", NameResourceType = typeof (Resources.SharedResource))]
        public DropDownListViewModel BackupEquipmentNumberList { get; set; }
    }
}