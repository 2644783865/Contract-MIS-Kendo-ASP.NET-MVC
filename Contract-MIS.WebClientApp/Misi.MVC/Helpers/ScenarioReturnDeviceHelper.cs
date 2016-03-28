using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioReturnDevice;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public class ScenarioReturnDeviceHelper
    {
        public static RequestInfoHeadingViewModel GenerateRequestInfoHeadingViewModel()
        {
            return new RequestInfoHeadingViewModel
            {
                //SnOrIdNumberList = DictionaryHelper.ToSelectListItems(ScenarioReturnDeviceResource.SnOrIdNumber1, ScenarioReturnDeviceResource.SnOrIdNumber2, ScenarioReturnDeviceResource.SnOrIdNumber3),
                //CompanyList = DictionaryHelper.ToSelectListItems(ScenarioReturnDeviceResource.Company1, ScenarioReturnDeviceResource.Company2),
                IssuedByList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(SharedResource.SalesAdmin, SharedResource.Warehouse, SharedResource.Workshop, SharedResource.Helpdesk)
                }
            };
        }

        public static RoutingInfoHeadingViewModel GenerateRoutingInfoHeadingViewModel()
        {
            return new RoutingInfoHeadingViewModel
            {
                PredefinedScenarioList = DictionaryHelper.ToSelectListItems(SharedResource.ReturnDevice, SharedResource.TransferAssets, SharedResource.Termination, SharedResource.Broken, SharedResource.ReturnDevice, SharedResource.ErrorCharges, SharedResource.ScenarioNew, SharedResource.NewContract),
                DeviceViewModel = new DeviceViewModel
                {
                    DeviceList = new DropDownListViewModel
                    {
                        Sources = DictionaryHelper.ToSelectListItems(SharedResource.Desktop, SharedResource.Laptop, SharedResource.Printer, SharedResource.IpPhone, SharedResource.ThinClient, SharedResource.Others)
                    }
                }
            };
        }

        public static ScenarioAttributeReturnDeviceViewModel GenerateScenarioAttributeReturnDeviceViewModel()
        {
            return new ScenarioAttributeReturnDeviceViewModel
            {
                UserHolderNameList = DictionaryHelper.ToSelectListItems(ScenarioReturnDeviceResource.UserHolderName1, ScenarioReturnDeviceResource.UserHolderName2, ScenarioReturnDeviceResource.UserHolderName3),
                UserSalaryNumberList = DictionaryHelper.ToSelectListItems(ScenarioReturnDeviceResource.UserSalaryNumber1, ScenarioReturnDeviceResource.UserSalaryNumber2, ScenarioReturnDeviceResource.UserSalaryNumber3)
                //ReturnDeliveryNumberList = DictionaryHelper.ToSelectListItems(ScenarioReturnDeviceResource.ReturnDeliveryNumber1, ScenarioReturnDeviceResource.ReturnDeliveryNumber2, ScenarioReturnDeviceResource.ReturnDeliveryNumber3),
                //NewLocationList = DictionaryHelper.ToSelectListItems(ScenarioReturnDeviceResource.NewLocation1, ScenarioReturnDeviceResource.NewLocation2, ScenarioReturnDeviceResource.NewLocation3)
            };
        }

        public static PreviewReturnDeviceViewModel GeneratePreviewReturnDeviceViewModel()
        {
            return new PreviewReturnDeviceViewModel();
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