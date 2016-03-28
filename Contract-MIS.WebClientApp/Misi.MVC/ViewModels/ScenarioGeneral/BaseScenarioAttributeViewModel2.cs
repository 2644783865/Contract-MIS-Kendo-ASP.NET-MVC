using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class BaseScenarioAttributeViewModel2
    {
        [LocalizedDisplayName("UserHolderName", NameResourceType = typeof (Resources.SharedResource))]
        public string UserHolderName { get; set; }

        [LocalizedDisplayName("UserSalaryNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string UserSalaryNumber { get; set; }

        [LocalizedDisplayName("NewLocation", NameResourceType = typeof (Resources.SharedResource))]
        public string NewLocation { get; set; }
    }
}