using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class ScenarioAttributeViewModel
    {
        [LocalizedDisplayName("HolderName", NameResourceType = typeof (SharedResource))]
        public string HolderName { get; set; }

        [LocalizedDisplayName("SalaryNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public int SalaryNumber { get; set; }

        [LocalizedDisplayName("SoDeliveryNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public int SoDeliveryNumber { get; set; }

        [LocalizedDisplayName("AssetNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public int AssetNumber { get; set; }

        [LocalizedDisplayName("CipNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public int CipNumber { get; set; }

        [LocalizedDisplayName("DeliveryOrderToUser", NameResourceType = typeof (ScenarioNewContractResource))]
        public int DeliveryOrderToUser { get; set; }

        [LocalizedDisplayName("NotificationNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public int NotificationNumber { get; set; }

        [LocalizedDisplayName("ExtentionLineNumber", NameResourceType = typeof (ScenarioNewContractResource))]
        public int ExtentionLineNumber { get; set; }

        [LocalizedDisplayName("ServiceDeliveryDate", NameResourceType = typeof (ScenarioNewContractResource))]
        public int ServiceDeliveryDate { get; set; }
    }
}