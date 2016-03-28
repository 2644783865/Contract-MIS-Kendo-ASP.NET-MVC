using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioReturnDevice
{
    public class RoutingInfoViewModel : BaseRoutingInfoViewModel
    {
        [LocalizedDisplayName("ReturnDeliveryNumber", NameResourceType = typeof (Resources.ScenarioReturnDeviceResource)
            )]
        public string ReturnDeliveryNumber { get; set; }
    }
}