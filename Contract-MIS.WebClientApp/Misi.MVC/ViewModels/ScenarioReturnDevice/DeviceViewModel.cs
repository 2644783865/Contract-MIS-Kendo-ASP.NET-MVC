using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioReturnDevice
{
    /// <summary>
    /// DeviceViewModel for Scenario Return Device
    /// </summary>
    public class DeviceViewModel
    {
        [Required]
        [LocalizedDisplayName("Device", NameResourceType = typeof (Resources.SharedResource))]
        public DropDownListViewModel DeviceList { get; set; }

        [LocalizedDisplayName("DeviceDescription", NameResourceType = typeof (Resources.SharedResource))]
        public string DeviceDescription { get; set; }
    }
}