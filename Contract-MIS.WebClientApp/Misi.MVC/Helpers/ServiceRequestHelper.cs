using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ServiceRequest;

namespace Misi.MVC.Helpers
{
    public class ServiceRequestHelper
    {
        public static string cTransferAssetsScenario = "Transfer Asset";
        public static string cTerminationScenario = "Termination";
        public static string cBroken= "Broken";
        public static string cErrorChargesScenario = "Error Charges";
        public static string cNewContractScenario = "New Contract";
        public static string cNewScenario = "New Scenario";
        public static string cReturnDevice = "Return Device";

        public static CreateServiceRequestViewModel GenerateCreateServiceRequestViewModel()
        {
            return new CreateServiceRequestViewModel()
            {
                IssuedByListItems = new ViewModels.Shared.DropDownListViewModel
                {   Sources =DictionaryHelper.ToSelectListItems(SharedResource.Helpdesk,
                    SharedResource.Warehouse,
                    SharedResource.Workshop,
                    SharedResource.SalesAdmin)
                },
                Scenarios = new ViewModels.Shared.DropDownListViewModel
                {
                   Sources = DictionaryHelper.ToSelectListItems(SharedResource.Termination,
                   SharedResource.ReturnDevice,
                   SharedResource.NewScenario,
                   SharedResource.NewContract,
                   SharedResource.ErrorCharges,
                   SharedResource.Broken,
                   SharedResource.TransferAsset)
                }
            };
        }

        public static MaintainServiceRequestViewModel GenerateMaintainServiceRequestViewModel()
        {
            return new MaintainServiceRequestViewModel()
            {
                SaStatusList = DictionaryHelper.ToSelectListItems(ServiceRequestResource.Checked, ServiceRequestResource.Unchecked),

                ReasonForRejection = DictionaryHelper.ToSelectListItems(ServiceRequestResource.BillingBlocked,
                ServiceRequestResource.TechnicalReason, ServiceRequestResource.CompletionOfContract, ServiceRequestResource.EquipmentRejection),

                RoutingStatusList = DictionaryHelper.ToSelectListItems(SharedResource.Completed,
                SharedResource.InProgress, SharedResource.NotStarted, SharedResource.Cancelled, SharedResource.RejectedBySa,
                SharedResource.RejectedByDivision),

                Scenarios = DictionaryHelper.ToSelectListItems(SharedResource.TransferAsset,
                SharedResource.Termination, SharedResource.ReturnDevice, SharedResource.Broken, SharedResource.ErrorCharges,
                SharedResource.NewContract, SharedResource.NewScenario),

                IssuedByListItems = DictionaryHelper.ToSelectListItems(SharedResource.Helpdesk,
                SharedResource.Warehouse, SharedResource.Workshop, SharedResource.SalesAdmin),
            };
        }
    }
}