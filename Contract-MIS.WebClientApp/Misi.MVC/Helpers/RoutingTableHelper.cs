using System;
using System.Collections.Generic;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public class RoutingTableHelper
    {
        public static RoutingTableViewModel GenerateRoutingTableViewModel(ScenarioType scenarioType)
        {
            return new RoutingTableViewModel
            {
                RoutingTableLineViewModels = GenerateRoutingTableLineViewModel(scenarioTypeChosen: scenarioType)
            };
        }

        private static IEnumerable<RoutingTableLineViewModel> GenerateRoutingTableLineViewModel(ScenarioType scenarioTypeChosen)
        {
            switch (scenarioTypeChosen)
            {
                //Scenario TransferAssetholder
                case ScenarioType.TransferAssetsHolder:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.Helpdesk),
                            Instruction = RoutingTableResources.TransferAssetHolderInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.WarehouseAdmin),
                            Instruction = RoutingTableResources.TransferAssetHolderInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 3,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.TransferAssetHolderInstruction3,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 4,
                            Divisions = GenerateDivisionViewModel(SharedResource.DeliveryAdmin),
                            Instruction = RoutingTableResources.TransferAssetHolderInstruction4,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //TransferAssetLocation
                case ScenarioType.TransferAssetsLocation:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.Helpdesk),
                            Instruction = RoutingTableResources.TransferAssetLocationInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.Asset),
                            Instruction = RoutingTableResources.TransferAssetLocationInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //Termination
                case ScenarioType.Termination:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.Helpdesk),
                            Instruction = RoutingTableResources.TerminationInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.Sales),
                            Instruction = RoutingTableResources.TerminationInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //ErrorCharges
                case ScenarioType.ErrorCharges:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //Broken
                case ScenarioType.Broken:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.Workshop),
                            Instruction = RoutingTableResources.BrokenInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //REturnDevice
                case ScenarioType.ReturnDevice:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.ScmWarehouseAdmin),
                            Instruction = RoutingTableResources.ReturnDeviceInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.ReturnDeviceInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //NewScenario
                case ScenarioType.ScenarioNew:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.Sales),
                            Instruction = RoutingTableResources.ScenarioNewInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //NewContractLDP
                case ScenarioType.NewContractLDP:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.WarehouseAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 3,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction3,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 4,
                            Divisions = GenerateDivisionViewModel(SharedResource.AssetAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction4,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 5,
                            Divisions = GenerateDivisionViewModel(SharedResource.WorkshopAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction5,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 6,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction6,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 7,
                            Divisions = GenerateDivisionViewModel(SharedResource.DeliveryAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction7,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 8,
                            Divisions = GenerateDivisionViewModel(SharedResource.AssetAdmin),
                            Instruction = RoutingTableResources.NewContractLDPInstruction8,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };

                //Scenario NewContractIpPhoneExtLine
                case ScenarioType.NewContractIpPhoneExtLine:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.WarehouseAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 3,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction3,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 4,
                            Divisions = GenerateDivisionViewModel(SharedResource.AssetAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction4,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 5,
                            Divisions = GenerateDivisionViewModel(SharedResource.WorkshopAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction5,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 6,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction6,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 7,
                            Divisions = GenerateDivisionViewModel(SharedResource.DeliveryAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction7,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 8,
                            Divisions = GenerateDivisionViewModel(SharedResource.AssetAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneExtLineInstruction8,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //Scenario NewContractIpPhone
                case ScenarioType.NewContractIPPhone:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.WarehouseAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 3,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction3,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 4,
                            Divisions = GenerateDivisionViewModel(SharedResource.AssetAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction4,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 5,
                            Divisions = GenerateDivisionViewModel(SharedResource.WorkshopAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction5,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 6,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction6,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 7,
                            Divisions = GenerateDivisionViewModel(SharedResource.DeliveryAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction7,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                         new RoutingTableLineViewModel()
                        {
                            Step = 8,
                            Divisions = GenerateDivisionViewModel(SharedResource.AssetAdmin),
                            Instruction = RoutingTableResources.NewContractIpPhoneInstruction8,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //Scenario NewContractExtLine
                case ScenarioType.NewContractExtLine:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractExtLineInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.SystemSupport),
                            Instruction = RoutingTableResources.NewContractExtLineInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                //Scenario NewContractSoftware
                case ScenarioType.NewContractSoftware:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewContractSoftwareInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.Helpdesk),
                            Instruction = RoutingTableResources.NewContractSoftwareInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
                    //Scenario New by default
                default:
                    return new List<RoutingTableLineViewModel>
                    {
                        new RoutingTableLineViewModel()
                        {
                            Step = 1,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewInstruction1,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                        new RoutingTableLineViewModel()
                        {
                            Step = 2,
                            Divisions = GenerateDivisionViewModel(SharedResource.SalesAdmin),
                            Instruction = RoutingTableResources.NewInstruction2,
                            Response = RoutingTableResources.Response,
                            Actual = DateTime.Now,
                            Plan = DateTime.Now,
                            Baseline = DateTime.Now,
                            RoutingStatusList = GenerateRoutingStatusListViewModel()
                        },
                    };
            }
        }

        private static DropDownListViewModel GenerateDivisionViewModel(string chosenPerson)
        {
            return new DropDownListViewModel
            {
                Sources = DictionaryHelper.ToSelectListItems(chosenPerson, true,
                            SharedResource.Helpdesk, SharedResource.Warehouse,
                            SharedResource.WarehouseAdmin, SharedResource.Sales,
                            SharedResource.SalesAdmin, SharedResource.DeliveryAdmin,
                            SharedResource.AssetAdmin,SharedResource.WorkshopAdmin,
                            SharedResource.SystemSupport, SharedResource.Asset, 
                            SharedResource.Workshop, SharedResource.ScmWarehouseAdmin)
            };
        }

        private static DropDownListViewModel GenerateRoutingStatusListViewModel()
        {
            return GeneralFormHelper.GenerateDropDownListViewModel(SharedResource.NotStarted, true,
                    SharedResource.Completed, SharedResource.InProgress, SharedResource.NotStarted, 
                    SharedResource.RejectedBySa, SharedResource.RejectedByDivision);
        }
    }
}