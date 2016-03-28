using System.Collections.Generic;
using Misi.MVC.ViewModels.ScenarioBroken;
using Misi.MVC.ViewModels.ScenarioErrorCharges;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.ScenarioNew;
using Misi.MVC.ViewModels.ScenarioNewContract;
using Misi.MVC.ViewModels.ScenarioReturnDevice;
using Misi.MVC.ViewModels.ScenarioTransferAssets;
using RoutingInfoHeadingViewModel = Misi.MVC.ViewModels.ScenarioErrorCharges.RoutingInfoHeadingViewModel;
using RoutingInfoViewModel = Misi.MVC.ViewModels.ScenarioTermination.RoutingInfoViewModel;
using RoutingTableViewModel = Misi.MVC.ViewModels.ScenarioGeneral.RoutingTableViewModel;

namespace Misi.MVC.Helpers
{
    public enum ScenarioType
    {
        TransferAssetsHolder, 
        TransferAssetsLocation,
        ErrorCharges,
        NewContractLDP,
        NewContractIPPhone,
        NewContractExtLine,
        NewContractIpPhoneExtLine,
        NewContractSoftware,
        ReturnDevice,
        ScenarioNew,
        ErrorCharge,
        Termination,
        Broken
    }

    public class ScenarioFormHelper
    {
        public static object GenerateViewModel(ScenarioType scenarioType)
        {
            switch (scenarioType)
            {

                //Scenario Termination 
                case ScenarioType.Termination:
                    return new RoutingInfoViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioTerminationHelper.GenerateRoutingInfoHeadingViewModel(),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType),
                        PreviewRequestInfoViewModel = ScenarioTerminationHelper.GeneratePreviewRequestInfoViewModels(scenarioType),
                    }; 


                //scenario ErrorChargesRoutingInfo
                case ScenarioType.ErrorCharges:
                    return new MVC.ViewModels.ScenarioErrorCharges.RoutingInfoViewModel()
                    {
                        RoutingInfoHeadingViewModel = new RoutingInfoHeadingViewModel(),
                        RoutingInfoMidViewModel = new RoutingInfoMidViewModel(),
                        RoutingInfoWorkflowViewModel = ScenarioErrorChargesHelper.GenerateRoutingInfoWorkflowViewModel(scenarioType)
                    };

                case ScenarioType.TransferAssetsLocation:
                    return new RoutingInfoLocationViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioTransferAssetsHelper.GenerateRoutingInfoHeadingViewModel(ScenarioType.TransferAssetsLocation),
                        ScenarioAttributeLocationViewModel = ScenarioTransferAssetsHelper.GenearateScenarioAttributeLocationViewModel(),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType)
                    };

                case ScenarioType.TransferAssetsHolder:
                    return new RoutingInfoHolderViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioTransferAssetsHelper.GenerateRoutingInfoHeadingViewModel(ScenarioType.TransferAssetsHolder),
                        ScenarioAttributeHolderViewModel = ScenarioTransferAssetsHelper.GenerateScenarioAttributeHolderViewModel(),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType)
                    };

                //scenario NewContractLDP
                case ScenarioType.NewContractLDP:
                    return new RoutingInfoLdpViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioNewContractHelper.GeneRoutingInfoHeadingViewModel(ScenarioType.NewContractLDP),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType),
                        ScenarioAttributeViewModel = new ScenarioAttributeViewModel()
                    };

                //scenario NewContractIpPhoneExtLine
                case ScenarioType.NewContractIpPhoneExtLine:
                    return new RoutingInfoIpPhoneExtLineViewModel
                    {
                        RoutingInfoHeadingViewModel = ScenarioNewContractHelper.GeneRoutingInfoHeadingViewModel(ScenarioType.NewContractIpPhoneExtLine),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType)
                    };

                //scenario NewContractIPPhone
                case ScenarioType.NewContractIPPhone:
                    return new RoutingInfoIPPhoneViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioNewContractHelper.GeneRoutingInfoHeadingViewModel(ScenarioType.NewContractIPPhone),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType),
                        ScenarioAttributeIpPhoneViewModel = new ScenarioAttributeViewModel()
                    };

                //scenario NewContractExtLine
                case ScenarioType.NewContractExtLine:
                    return new RoutingInfoExtLineViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioNewContractHelper.GeneRoutingInfoHeadingViewModel(ScenarioType.NewContractExtLine),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType),
                        ScenarioAttributeExtLineViewModel = new ScenarioAttributeViewModel()
                    };

                //scenario NewContractSoftware
                case ScenarioType.NewContractSoftware:
                    return new RoutingInfoSoftwareViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioNewContractHelper.GeneRoutingInfoHeadingViewModel(ScenarioType.NewContractSoftware),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType),
                        ScenarioAttributeSoftwareViewModel = new ScenarioAttributeViewModel()
                    };

                 case ScenarioType.Broken:
                    return new RoutingInfoBrokenViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioBrokenHelper.GenerateRoutingInfoHeadingViewModel(),
                        ScenarioAttributeBrokenViewModel = ScenarioBrokenHelper.GeneraScenarioAttributeBrokenViewModel(),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType)
                    };

                case ScenarioType.ReturnDevice:
                    return new RoutingInfoReturnDeviceViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioReturnDeviceHelper.GenerateRoutingInfoHeadingViewModel(),
                        ScenarioAttributeReturnDeviceViewModel = ScenarioReturnDeviceHelper.GenerateScenarioAttributeReturnDeviceViewModel(),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType)
                    };
                  case ScenarioType.ScenarioNew:
                    return new RoutingInfoNewScenarioViewModel()
                    {
                        RoutingInfoHeadingViewModel = ScenarioNewHelper.GenerateRoutingInfoHeadingViewModel(),
                        ScenarioAttributeNewScenarioViewModel = new ScenarioAttributeNewScenarioViewModel(),
                        RoutingTableViewModel = RoutingTableHelper.GenerateRoutingTableViewModel(scenarioType)
                    };


                default:
                    return null;
            }
        }

       
    }
}