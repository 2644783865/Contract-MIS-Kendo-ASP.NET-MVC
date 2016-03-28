using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioNew
{
    public class RoutingInfoViewModel : BaseRoutingInfoViewModel
    {
        [LocalizedDisplayName("AttributeDescription", NameResourceType = typeof (Resources.ScenarioNewResource))]
        public string AttributeDescription { get; set; }
    }
}