using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioBroken;
using Misi.MVC.ViewModels.Shared;


namespace Misi.MVC.Helpers
{
    public class ScenarioBrokenHelper
    {
        public static RequestInfoHeadingViewModel GenerateRequestInfoHeadingViewModel()
        {
            return new RequestInfoHeadingViewModel
            {
                //SnOrIdNumberList = DictionaryHelper.ToSelectListItems(ScenarioBrokenResource.SnOrIdNumber1, ScenarioBrokenResource.SnOrIdNumber2, ScenarioBrokenResource.SnOrIdNumber3),
                //CompanyList = DictionaryHelper.ToSelectListItems(ScenarioBrokenResource.Company1, ScenarioBrokenResource.Company2, ScenarioBrokenResource.Company3),
                IssuedByList = DictionaryHelper.ToSelectListItems(ScenarioBrokenResource.Workshop, 
                        ScenarioBrokenResource.Helpdesk, 
                        ScenarioBrokenResource.Warehouse, 
                        ScenarioBrokenResource.SalesAdmin)
                
            }; 
        }

        public static RoutingInfoHeadingViewModel GenerateRoutingInfoHeadingViewModel()
        {
            return new RoutingInfoHeadingViewModel
            {
                PredefinedScenarioList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(SharedResource.TransferAssets, SharedResource.Termination, SharedResource.Broken, SharedResource.ReturnDevice, SharedResource.ErrorCharges, SharedResource.NewScenario, SharedResource.NewContract)
                },
                DeviceList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(SharedResource.Desktop, SharedResource.Laptop, SharedResource.Printer, SharedResource.IpPhone, SharedResource.ThinClient, SharedResource.Others)
                }
                //SnDeviceList = DictionaryHelper.ToSelectListItems(ScenarioBrokenResource.SnDevice1, ScenarioBrokenResource.SnDevice2, ScenarioBrokenResource.SnDevice3)
            };


        }

        public static ScenarioAttributeBrokenViewModel GeneraScenarioAttributeBrokenViewModel()
        {
            return new ScenarioAttributeBrokenViewModel
            {
                UserHolderNameList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(ScenarioBrokenResource.UserHolderName1, ScenarioBrokenResource.UserHolderName2, ScenarioBrokenResource.UserHolderName3)
                },
                UserSalaryNumberList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(ScenarioBrokenResource.UserSalaryNumber1, ScenarioBrokenResource.UserSalaryNumber2, ScenarioBrokenResource.UserSalaryNumber3)
                },
                BackupEquipmentNumberList = new DropDownListViewModel
                {
                    Sources = DictionaryHelper.ToSelectListItems(ScenarioBrokenResource.BackupEquipmentNumber1, ScenarioBrokenResource.BackupEquipmentNumber2, ScenarioBrokenResource.BackupEquipmentNumber3)
                }
            };
        }

        public static PreviewBrokenViewModel GeneratePreviewBrokenViewModel()
        {
            return new PreviewBrokenViewModel();
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