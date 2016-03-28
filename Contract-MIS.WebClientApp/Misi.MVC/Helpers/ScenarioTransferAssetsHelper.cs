using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Kendo.Mvc.Infrastructure;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.ScenarioTransferAssets;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public class ScenarioTransferAssetsHelper
    {

        public static RequestInfoHeadingViewModel GenerateRequestInfoHeadingViewModel()
        {
            return new RequestInfoHeadingViewModel()
            {
                //SnOrIdNumberList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.SnOrIdNumber1, ScenarioTransferAssetsResource.SnOrIdNumber2, ScenarioTransferAssetsResource.SnOrIdNumber3),
                //CompanyList = DictionaryHelper.ToSelectListItems(SharedResources.Trakindo, SharedResources.Stiech, SharedResources.Mst),
                TicketCategoryViewModel = new TicketCategoryViewModel()
                //RequestedViaList = DictionaryHelper.ToSelectListItems(SharedResources.Email, SharedResources.Phone),
                //IssuedByList = DictionaryHelper.ToSelectListItems(SharedResources.Workshop, SharedResources.SalesAdmin, SharedResources.Helpdesk, SharedResources.Warehouse)
            };
        }

        public static RoutingInfoHeadingViewModel GenerateRoutingInfoHeadingViewModel(ScenarioType scenarioType)
        {
            return new RoutingInfoHeadingViewModel
            {

                DeviceList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(SharedResource.Desktop, SharedResource.Laptop, SharedResource.Printer, SharedResource.IpPhone, SharedResource.ThinClient, SharedResource.Others)
                },
                
                
                //ContractNumberViewModel = new ContractNumberViewModel()
                //{
                //    ContractNumberList =  DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.CustomerNumber1, ScenarioTransferAssetsResource.CustomerNumber2)
                //}, 
                PredefinedScenarioViewModel = GeneratePredefinedScenarioViewModel(scenarioTypeChosen: scenarioType)
                
            };
        }

        public static PredefinedScenarioViewModel GeneratePredefinedScenarioViewModel(ScenarioType scenarioTypeChosen)
        {
            string chosenSubScenario;
            switch (scenarioTypeChosen)
            {
                case ScenarioType.TransferAssetsHolder:
                    {
                        chosenSubScenario = ScenarioTransferAssetsResource.Holder;
                        break;
                    }

                case ScenarioType.TransferAssetsLocation:
                    {
                        chosenSubScenario = ScenarioTransferAssetsResource.Location;
                        break;
                    }

                default:
                    {
                        chosenSubScenario = ScenarioTransferAssetsResource.Holder;
                        break;
                    }
            }
            return new PredefinedScenarioViewModel
            {
                PredefinedScenario = DictionaryHelper.ToSelectListItems(SharedResource.TransferAsset,
                    SharedResource.NewContract,
                    SharedResource.Termination,
                    SharedResource.ReturnDevice,
                    SharedResource.Broken,
                    SharedResource.NewScenario),
                SubPredefinedScenarioList = DictionaryHelper.ToSelectListItems(chosenSubScenario, true,
                    ScenarioTransferAssetsResource.Holder,
                    ScenarioTransferAssetsResource.Location)
            };
        }

        public static ScenarioAttributeHolderViewModel GenerateScenarioAttributeHolderViewModel()
        {
            return new ScenarioAttributeHolderViewModel
            {
                NewContractNumberViewModel = new NewContractNumberViewModel()
                {
                    //NewContractNumberList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.NewContractNumbe1, ScenarioTransferAssetsResource.NewContractNumbe2, ScenarioTransferAssetsResource.NewContractNumbe3)
                }

                //ReturnDeliveryOrderList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.ReturnDeliveryOrder1, ScenarioTransferAssetsResource.ReturnDeliveryOrder2, ScenarioTransferAssetsResource.ReturnDeliveryOrder3),
                //NewHolderNameList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.NewHolderName1, ScenarioTransferAssetsResource.NewHolderName2, ScenarioTransferAssetsResource.NewHolderName3),
                //NewSalaryNumberList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.NewSalaryNumber1, ScenarioTransferAssetsResource.NewSalaryNumber2, ScenarioTransferAssetsResource.NewSalaryNumber3)
            };
        }

        public static ScenarioAttributeLocationViewModel GenearateScenarioAttributeLocationViewModel()
        {
            return new ScenarioAttributeLocationViewModel
            {
                OldLocationList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.OldLocation1, ScenarioTransferAssetsResource.OldLocation2, ScenarioTransferAssetsResource.OldLocation3),
                UserHolderNameList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.UserHolderName1, ScenarioTransferAssetsResource.UserHolderName2, ScenarioTransferAssetsResource.UserHolderName3),
                UserSalaryNumberList = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.UserSalaryNumber1, ScenarioTransferAssetsResource.UserSalaryNumber2, ScenarioTransferAssetsResource.UserSalaryNumber3),
                NewLocationList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(ScenarioTransferAssetsResource.NewLocation1, ScenarioTransferAssetsResource.NewLocation2, ScenarioTransferAssetsResource.NewLocation3)
                }
            };
        }

        //public static PreviewServiceRequestViewModel GeneratePreviewServiceRequestViewModel()
        //{

        //    return new PreviewServiceRequestViewModel { };
        //}

        public static PreviewTransferAssetsViewModel GeneratePreviewTransferAssetsViewModel()
        {
            return new PreviewTransferAssetsViewModel();

        }


        public static RequestInfoViewModel GenerateRequestInfoViewModel()
        {
            return new RequestInfoViewModel
            {
                RequestInfoHeadingViewModel = GenerateRequestInfoHeadingViewModel()
            };
        }
    }
}