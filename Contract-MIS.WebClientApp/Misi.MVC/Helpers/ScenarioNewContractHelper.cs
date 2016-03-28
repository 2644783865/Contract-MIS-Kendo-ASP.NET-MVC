using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.ScenarioNewContract;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public class ScenarioNewContractHelper
    {
        public static RequestInfoViewModel GenerateRequestInfoViewModel()
        {
            return new RequestInfoViewModel
            {
                RequestInfoHeadingViewModel = GenerateRequestInfoMainViewModel()
            };
        }

        public static RequestInfoHeadingViewModel GenerateRequestInfoMainViewModel()
        {
            return new RequestInfoHeadingViewModel
            {
                CompanyListItems = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(ScenarioNewContractResource.Trakindo,
                        ScenarioNewContractResource.Mahadasha)
                },
                RequestedviaListItems = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(ScenarioNewContractResource.IdrWeb,
                        ScenarioNewContractResource.PoManual)
                },
                IssuedByListItems = DictionaryHelper.ToSelectListItems(ScenarioTerminationResource.SalesAdmin,
                    ScenarioTerminationResource.Warehouse,
                    ScenarioTerminationResource.Workshop,
                    ScenarioTerminationResource.Helpdesk)
            };
        }

        public static RoutingInfoHeadingViewModel GeneRoutingInfoHeadingViewModel(ScenarioType scenarioType)
        {
            return new RoutingInfoHeadingViewModel
            {
                PredefinedScenarioViewModel = GeneratePredefinedScenarioViewModel(scenarioTypeChosen: scenarioType),
                SoftwareTypeViewModel = GeneraSoftwareTypeViewModel()
            };
        }

        public static PredefinedScenarioViewModel GeneratePredefinedScenarioViewModel(ScenarioType scenarioTypeChosen)
        {
            string chosenSubScenario;
            switch (scenarioTypeChosen)
            {
                case ScenarioType.NewContractLDP:
                {
                    chosenSubScenario = ScenarioNewContractResource.Ldp;
                    break;
                }

                case ScenarioType.NewContractIPPhone:
                {
                    chosenSubScenario = ScenarioNewContractResource.IpPhone;
                    break;
                }

                case ScenarioType.NewContractExtLine:
                {
                    chosenSubScenario = ScenarioNewContractResource.ExtLine;
                    break;
                }

                case ScenarioType.NewContractIpPhoneExtLine:
                {
                    chosenSubScenario = ScenarioNewContractResource.IpPhoneExtLine;
                    break;
                }

                default:
                {
                    chosenSubScenario = ScenarioNewContractResource.Software;
                    break;
                }
            }
            return new PredefinedScenarioViewModel
            {
                PredefinedScenario = DictionaryHelper.ToSelectListItems(ScenarioNewContractResource.NewContract,
                    ScenarioNewContractResource.TransferAsset,
                    ScenarioNewContractResource.Termination,
                    ScenarioNewContractResource.ReturnDevice,
                    ScenarioNewContractResource.Broken,
                    ScenarioNewContractResource.CustomScenario),
                SubPredefinedScenarioList = DictionaryHelper.ToSelectListItems(chosenSubScenario, true,
                    ScenarioNewContractResource.Ldp,
                    ScenarioNewContractResource.IpPhone,
                    ScenarioNewContractResource.ExtLine,
                    ScenarioNewContractResource.IpPhoneExtLine,
                    ScenarioNewContractResource.Software)
            };
        }

        public static SoftwareTypeViewModel GeneraSoftwareTypeViewModel()
        {
            return new SoftwareTypeViewModel
            {
                SoftwareListItems = DictionaryHelper.ToSelectListItems(ScenarioNewContractResource.DbsId,
                    ScenarioNewContractResource.EmailExchange,
                    ScenarioNewContractResource.AksesAd,
                    ScenarioNewContractResource.EmailMaintenance)
            };
        }

        public static PreviewNewContractViewModel GeneratePreviewNewContractViewModel()
        {
            return new PreviewNewContractViewModel
            {
                PreviewRequestInfoViewModel = GeneratePreviewRequestInfoViewModel()
            };
        }

        public static PreviewRequestInfoViewModel GeneratePreviewRequestInfoViewModel()
        {
            return new PreviewRequestInfoViewModel
            {
                PreviewRequestInfoTableLineViewModel = new List<PreviewRequestInfoTableLineViewModel>(),
                PreviewRequestInfoSubTableViewModel = new List<PreviewRequestInfoSubTableViewModel>()
            };
        }
    }
}