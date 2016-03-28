using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioNew;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public class ScenarioNewHelper
    {
        public static RequestInfoHeadingViewModel GenerateRequestInfoHeadingViewModel()
        {
            return new RequestInfoHeadingViewModel
            {
                //SnOrIdNumberList = DictionaryHelper.ToSelectListItems(ScenarioNewResource.SnOrIdNumber1, ScenarioNewResource.SnOrIdNumber2, ScenarioNewResource.SnOrIdNumber3),
                //CompanyList = DictionaryHelper.ToSelectListItems(ScenarioNewResource.Company1, ScenarioNewResource.Company2),
                IssuedByList = DictionaryHelper.ToSelectListItems(SharedResource.SalesAdmin, SharedResource.Warehouse, SharedResource.Workshop, SharedResource.Helpdesk)
            };
        }

        public static RoutingInfoHeadingViewModel GenerateRoutingInfoHeadingViewModel()
        {
            return new RoutingInfoHeadingViewModel
            {
                PredefinedScenarioViewModel = new PredefinedScenarioViewModel()
                {
                    PredefinedScenarioList = new DropDownListViewModel
                    {
                        Sources = DictionaryHelper.ToSelectListItems(SharedResource.TransferAssets, SharedResource.Termination, SharedResource.Broken, SharedResource.ReturnDevice, SharedResource.ErrorCharges, SharedResource.NewScenario, SharedResource.NewContract)
                    }
                },
                DeviceList = DictionaryHelper.ToSelectListItems(SharedResource.Laptop, SharedResource.Phone)
            };
        }

        public static PreviewNewViewModel GeneratePreviewNewViewModel()
        {
            return new PreviewNewViewModel();
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