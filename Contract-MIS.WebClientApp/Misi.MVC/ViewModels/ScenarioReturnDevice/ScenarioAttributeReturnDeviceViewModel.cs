using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioReturnDevice
{
    public class ScenarioAttributeReturnDeviceViewModel : BaseScenarioAttributeViewModel
    {
        [Required]
        [LocalizedDisplayName("UserHolderName", NameResourceType = typeof (Resources.ScenarioReturnDeviceResource))]
        public IEnumerable<SelectListItem> UserHolderNameList { get; set; }

        [Required]
        [LocalizedDisplayName("UserSalaryNumber", NameResourceType = typeof (Resources.ScenarioReturnDeviceResource))]
        public IEnumerable<SelectListItem> UserSalaryNumberList { get; set; }

        [Required]
        [LocalizedDisplayName("ReturnDeliveryNumber", NameResourceType = typeof (Resources.ScenarioReturnDeviceResource))]
        public string ReturnDeliveryNumber { get; set; }

        [Required]
        [LocalizedDisplayName("NewLocation", NameResourceType = typeof (Resources.ScenarioReturnDeviceResource))]
        public string NewLocation { get; set; }
    }
}