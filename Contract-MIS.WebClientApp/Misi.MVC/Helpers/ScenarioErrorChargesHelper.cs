using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioErrorCharges;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public class ScenarioErrorChargesHelper
    {
        public static RequestInfoViewModel GenerateRequestInfoViewModel()
        {
            return new RequestInfoViewModel
            {
                RequestInfoMainViewModel = GenerateRequestInfoMainViewModel()
            };
        }
        public static RequestInfoHeadingViewModel GenerateRequestInfoMainViewModel()
        {
            return new RequestInfoHeadingViewModel
            {
                //CompanyListItems = DictionaryHelper.ToSelectListItems(ScenarioNewContractResource.Trakindo,
               // ScenarioNewContractResource.Mahadasha),

                IssuedByListItems = DictionaryHelper.ToSelectListItems(ScenarioTerminationResource.SalesAdmin,
                ScenarioTerminationResource.Helpdesk,
                ScenarioTerminationResource.Warehouse,
                ScenarioTerminationResource.Workshop
                ),

               // RequestedViaListItems = DictionaryHelper.ToSelectListItems(ScenarioNewContractResource.IdrWeb,
               // ScenarioNewContractResource.PoManual)//
            };
        }

        public static RoutingInfoWorkflowViewModel GenerateRoutingInfoWorkflowViewModel(ScenarioType scenarioType)
        {
            return new RoutingInfoWorkflowViewModel
            {
                RoutingInfoWorkflowTableViewModel = GenerateRoutingInfoWorkflowTableViewModel()
            };
        }

        private static IEnumerable<RoutingInfoWorkflowTableViewModel> GenerateRoutingInfoWorkflowTableViewModel()
        {
                return new List<RoutingInfoWorkflowTableViewModel>
                {
                    new RoutingInfoWorkflowTableViewModel()
                    {
                        RoutingStatusListItems = GenerateRoutingStatusListViewModel()
                    }
                };
        }

        private static DropDownListViewModel GenerateRoutingStatusListViewModel()
        {
            return GeneralFormHelper.GenerateDropDownListViewModel(SharedResource.NotStarted, true,
                    SharedResource.Completed, SharedResource.InProgress, SharedResource.NotStarted,
                    SharedResource.RejectedBySa, SharedResource.RejectedByDivision);
        }

        public static PreviewErrorChargesViewModel GeneratePreviewErrorChargesViewModel()
        {
            return new PreviewErrorChargesViewModel
            {
                PreviewRequestInfoViewModel = GeneratePreviewRequestInfoViewModel()
            };
        }

        public static PreviewRequestInfoViewModel GeneratePreviewRequestInfoViewModel()
        {
            return new PreviewRequestInfoViewModel
            {
                PreviewRequestInfoTableViewModel = new List<PreviewRequestInfoTableViewModel>(),
                PreviewRequestInfoSubTableViewModel = new List<PreviewRequestInfoSubTableViewModel>()
            };
        }
    }
}