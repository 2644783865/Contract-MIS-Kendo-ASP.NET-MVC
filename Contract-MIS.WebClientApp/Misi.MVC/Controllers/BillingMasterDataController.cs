using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Elmah;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.SAPServiceClient;
using Misi.MVC.ServiceClient;
using Misi.MVC.ViewModels.MasterData;

namespace Misi.MVC.Controllers
{
    [HandleError] 
    public class BillingMasterDataController : Controller
    {
        public JsonResult GetBillingRunBySoldToPartyJson(string soldToPartId)
        {
            InvoiceProformaBillingRunDTO[] serviceModel = null;
            try
            {
                serviceModel = WCFClientManager.SAPServiceClient.QueryBillingRunsFromDB(UserManagementHelper.GetSessionId());
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(JsonHelper.GenerateEmptyJson(), JsonRequestBehavior.AllowGet);
            }

            if (serviceModel == null || !serviceModel.Any())
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception(ErrorResource.WCFNullObject));
                return Json(JsonHelper.GenerateEmptyJson(), JsonRequestBehavior.AllowGet);
            }

            var viewModel = BillingMasterDataHelper.GenerateBillingRunMasterDataViewModel(soldToPartId, serviceModel);
            var jsonModel = JsonHelper.ConvertToJson(viewModel, typeof(BillingRunMasterDataViewModel), displayIdProperty: true);
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetBillingRunJson(string soldToParty = null, 
            string dateFrom = null, 
            string dateTo = null)
        {
            InvoiceProformaBillingRunDTO[] serviceModel = null;
            try
            {
                serviceModel = WCFClientManager.SAPServiceClient.QueryBillingRunsFromDB(UserManagementHelper.GetSessionId());
                serviceModel = GetOrderedServiceModel(serviceModel);
                serviceModel = FilterFromParameters(serviceModel, soldToParty, dateFrom, dateTo);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(JsonHelper.GenerateEmptyJson(), JsonRequestBehavior.AllowGet);
            }

            if (serviceModel == null || !serviceModel.Any())
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception(ErrorResource.WCFNullObject));
                return Json(JsonHelper.GenerateEmptyJson(), JsonRequestBehavior.AllowGet);
            }

            var viewModel = BillingMasterDataHelper.GenerateBillingRunMasterDataViewModel(serviceModel);
            var jsonModel = JsonHelper.ConvertToJson(viewModel, typeof(BillingRunMasterDataViewModel), displayIdProperty: false);
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }

        private InvoiceProformaBillingRunDTO[] GetOrderedServiceModel(IEnumerable<InvoiceProformaBillingRunDTO> serviceModel)
        {
            return serviceModel.OrderBy(e => e.SoldToParty)
                .ThenByDescending(e => e.Version)
                .ThenByDescending(e => e.Created)
                .ThenByDescending(e => e.No).ToArray();
        }

        private static InvoiceProformaBillingRunDTO[] FilterFromParameters(
            InvoiceProformaBillingRunDTO[] serviceModel,
            string soldToParty , 
            string dateFrom , 
            string dateTo)
        {
            if (string.IsNullOrEmpty(soldToParty) && string.IsNullOrEmpty(dateFrom) && string.IsNullOrEmpty(dateTo))
                return serviceModel;

            if (!(string.IsNullOrEmpty(soldToParty) || soldToParty == SharedResource.NA))
                serviceModel = serviceModel.Where(e => e.SoldToParty == soldToParty).ToArray();

            if (!string.IsNullOrEmpty(dateFrom))
            {
                var dateFromValue = DictionaryHelper.KendoDatePickerDateStringToDateTime(dateFrom);
                serviceModel = serviceModel.Where(e => e.StartDate >= dateFromValue).ToArray();
            }

            if (!string.IsNullOrEmpty(dateTo))
            {
                var dateToValue = DictionaryHelper.KendoDatePickerDateStringToDateTime(dateTo);
                serviceModel = serviceModel.Where(e => e.EndDate <= dateToValue).ToArray();
            }

            return serviceModel;
        }
    }
}