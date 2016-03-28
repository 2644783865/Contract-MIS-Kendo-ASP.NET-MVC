using System.ComponentModel;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class DummyBaseRoutingInfoViewModel
    {
        public DummyBaseRoutingInfoHeadingViewModel DummyBaseRoutingInfoHeadingViewModel { get; set; }
        public DummyBaseScenarioAttributeViewModel DummyBaseScenarioAttributeViewModel { get; set; }
        public RoutingTableViewModel RoutingTableViewModel { get; set; }
    }

    public class DummyBaseScenarioAttributeViewModel
    {
        public string BaseScenarioProperty { get; set; }
    }

    public class DummyBaseRoutingInfoHeadingViewModel
    {
        [DisplayName("asasas")]
        public string BaseRoutingHeadingProperty { get; set; }
    }


    public class SpecificRoutingInfoHeadingViewModel : DummyBaseRoutingInfoHeadingViewModel
    {
        public string SpecificHeadingProperty { get; set; }
    }

    public class SpecificScenarioAttributeViewModel : DummyBaseScenarioAttributeViewModel
    {
        public string SpecificScenarioAttributeProperty { get; set; }
    }
}