using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioTermination;

namespace Misi.MVC.Helpers
{
    public class ScenarioTerminationHelper
    {
        public static PreviewRequestInfoViewModel GeneratePreviewRequestInfoViewModels(ScenarioType scenarioType)
        {
            return new PreviewRequestInfoViewModel
            {
                PreviewRequestInfoTableViewModel = GeneratePreviewRequestInfoTableViewModel()
            };
        }

        private static IEnumerable<PreviewRequestInfoTableViewModel> GeneratePreviewRequestInfoTableViewModel()
        {
            return new List<PreviewRequestInfoTableViewModel>
            {
                new PreviewRequestInfoTableViewModel()
                {
                    Item = 10,
                    ServiceId = ScenarioTerminationResource.Serviceid1,
                    Scenario = ScenarioTerminationResource.Termination,
                    DetailScenario = ScenarioTerminationResource.DbsId,
                    IssuedBy = ScenarioTerminationResource.Helpdesk,
                    IssuedDate = DateTime.Now,
                    RequestedVia = ScenarioTerminationResource.email,
                    RequestMemo = ScenarioTerminationResource.RequestMemo1
                },
                new PreviewRequestInfoTableViewModel
                {
                    Item = 11,
                    ServiceId = ScenarioTerminationResource.Serviceid1,
                    Scenario = ScenarioTerminationResource.Termination,
                    DetailScenario = ScenarioTerminationResource.DbsId,
                    IssuedBy = ScenarioTerminationResource.Helpdesk,
                    IssuedDate = DateTime.Now,
                    RequestedVia = ScenarioTerminationResource.email,
                    RequestMemo = ScenarioTerminationResource.RequestMemo1
                },
                new PreviewRequestInfoTableViewModel
                {
                    Item = 12,
                    ServiceId = ScenarioTerminationResource.Serviceid1,
                    Scenario = ScenarioTerminationResource.Termination,
                    DetailScenario = ScenarioTerminationResource.DbsId,
                    IssuedBy = ScenarioTerminationResource.Helpdesk,
                    IssuedDate = DateTime.Now,
                    RequestedVia = ScenarioTerminationResource.email,
                    RequestMemo = ScenarioTerminationResource.RequestMemo1
                }
            };
        }

        public static RequestInfoViewModel GenerateRequestInfoViewModel()
        {
            return new RequestInfoViewModel
            {
                RequestInfoHeadingViewModel = GenerateRequestInfoHeadingViewModel()
            };
        }

        public static RequestInfoHeadingViewModel GenerateRequestInfoHeadingViewModel()
        {
            return new RequestInfoHeadingViewModel
            {
                TerminationRequestInfoLineViewModels = new List<TerminationRequestInfoLineViewModel>(),

                DetailScenariosListItems = DictionaryHelper.ToSelectListItems(ScenarioTerminationResource.DbsService,
                ScenarioTerminationResource.EmailService,
                ScenarioTerminationResource.AdAccess,
                ScenarioTerminationResource.Extention,
                ScenarioTerminationResource.Others),

                IssuedByListItems = DictionaryHelper.ToSelectListItems(ScenarioTerminationResource.Helpdesk,
                ScenarioTerminationResource.Warehouse,
                ScenarioTerminationResource.Workshop,
                ScenarioTerminationResource.SalesAdmin),

                RequestedViaListItems = DictionaryHelper.ToSelectListItems(ScenarioTerminationResource.email, 
                ScenarioTerminationResource.Telephone,ScenarioTerminationResource.Others),

            };
        }
        public static RoutingInfoHeadingViewModel GenerateRoutingInfoHeadingViewModel()
        {
            return new RoutingInfoHeadingViewModel
            {
                TerminationRoutingInfoLineViewModels = new List<TerminationRoutingInfoLineViewModel>(),
                DetailScenarioListItems = DictionaryHelper.ToSelectListItems(ScenarioTerminationResource.DbsService,
                ScenarioTerminationResource.EmailService,
                ScenarioTerminationResource.AdAccess,
                ScenarioTerminationResource.Extention,
                ScenarioTerminationResource.Others),

                Scenario = DictionaryHelper.ToSelectListItems(ScenarioTerminationResource.Termination)

            };
        }

        public static PreviewTerminationViewModel GeneratePreviewTerminationViewModel()
        {
            return new PreviewTerminationViewModel
            {
                PreviewRequestInfoViewModel = GeneratePreviewRequestInfoViewModel()
            };
        }

        public static PreviewRequestInfoViewModel GeneratePreviewRequestInfoViewModel()
        {
            return new PreviewRequestInfoViewModel
            {
                PreviewRequestInfoTableViewModel = GeneratePreviewRequestInfoTableViewModel(),
            };
        }
    }
}