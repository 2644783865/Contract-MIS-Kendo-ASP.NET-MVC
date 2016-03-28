using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Misi.MVC.Filters;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.SAPServiceClient;
using Misi.MVC.ServiceClient;
using Misi.MVC.ViewModels.ProformaInvoice;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Controllers
{
    [Filters.HandleError]
    [ADSAPAuthorize]
    public class ProformaInvoiceController : Controller
    {
        // GET: ProformaInvoice
        public ActionResult Index()
        {
            return RedirectToAction("Main");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Main()
        {
            // Clear existing session variables
            System.Web.HttpContext.Current.Session["RunInvoiceHeaderStacks"] = null;

            var viewModel = ProformaInvoiceHelper.GenerateMainProformaInvoiceViewModel();
            return View(viewModel);
        }

        /// <summary>
        /// POST menthod to proccess data given by Main screen. After being invoked, Popup will be displayed.
        /// </summary>
        /// <param name="iModel"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult BillingDocument(MainProformaInvoiceViewModel iModel)
        {
            BillingNumberItemDTO[] billingNumber;
            try
            {
                var dateFrom = DictionaryHelper.KendoDatePickerDateStringToDateTime(iModel.DateFromValue);
                var dateTo = DictionaryHelper.KendoDatePickerDateStringToDateTime(iModel.DateToValue);
                billingNumber = WCFClientManager.SAPServiceClient.QueryBillingNumbers(UserManagementHelper.GetSessionId(),
                    iModel.SoldToFromValue, dateFrom, dateTo); 
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(new {html = ErrorResource.WCFCannotGetObjectHTML});
            }

            var viewModel = ProformaInvoiceHelper.GeneratePopupBillingDocumentViewModel(billingNumber, iModel);
            var renderedHtml = ViewHelper.RenderPartialViewToString(this, "_PartialPopupBillingDocumentList", viewModel);
            return Json(new {html = renderedHtml});
        }

        /// <summary>
        /// GET Run ProformaInvoice from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Run(int? id)
        {
            RunInvoiceHeaderDTO serviceModel;
            try
            {
                //this should trigger the WCF to prepare billing items after being invoked
                //the mechanism to call is EXACTLY SAME with the mechanism to call service from SAP (in the beginning)
                serviceModel = WCFClientManager.SAPServiceClient.QueryRunInvoiceHeaderFromDB(
                    UserManagementHelper.GetSessionId(), id ?? 0);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return RedirectToAction("Index", "Error");
            }

            if (serviceModel == null)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception(ErrorResource.WCFNullObject));
                return RedirectToAction("Index", "Error", new {errorKey = "WCFNullObject"});
            }

            PopulateCategories();
            var viewModel = ProformaInvoiceHelper.GenerateRunProformaInvoiceViewModel(serviceModel);
            return View(viewModel);
        }

        /// <summary>
        /// GET Display ProformaInvoice from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Display(int id)
        {
            RunInvoiceHeaderDTO serviceModel;

            try
            {
                //this should trigger the WCF to prepare billing items after being invoked
                //the mechanism to call is EXACTLY SAME with the mechanism to call service from SAP (in the beginning)
                serviceModel = WCFClientManager.SAPServiceClient.QueryRunInvoiceHeaderFromDB(
                    UserManagementHelper.GetSessionId(), id);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return RedirectToAction("Index", "Error");
            }

            if (serviceModel == null)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception(ErrorResource.WCFNullObject));
                return RedirectToAction("Index", "Error", new {errorKey = "WCFNullObject"});
            }

            var viewModel = ProformaInvoiceHelper.GenerateRunProformaInvoiceViewModel(serviceModel);
            PopulateCategories();
            return View(viewModel);
        }

        /// <summary>
        /// POST method to store given parameters on the session required by GET CreateNew
        /// </summary>
        /// <param name="iModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Run(PopupBillingDocumentViewModel iModel)
        {
            RunInvoiceHeaderDTO serviceModel;
            int numberOfRows = 0;
            
            try
            {
                serviceModel = WCFClientManager.SAPServiceClient.QueryRunInvoiceHeader(UserManagementHelper.GetSessionId(),iModel.Lines.SelectedValue, iModel.IsBlockedDocSelectedValue, iModel.IsBlockedDocSelectedValue,iModel.IsActiveDocSelectedValue);
                numberOfRows = WCFClientManager.SAPServiceClient.QueryTotalBillingRecords(UserManagementHelper.GetSessionId());
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(new { urlToRedirect = "Error/" }, JsonRequestBehavior.AllowGet);
            }

            if (serviceModel == null)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception(ErrorResource.WCFNullObject));
                return Json(new { urlToRedirect = "Error/" }, JsonRequestBehavior.AllowGet);
            }

            var viewModel = ProformaInvoiceHelper.GenerateRunProformaInvoiceViewModel(serviceModel);
            viewModel.EstimatedProcessTime = numberOfRows/11;

            // Push to temporary stack in order that posted data can be accessed through GET 
            var runInvoiceHeaderStacks = System.Web.HttpContext.Current.Session["RunInvoiceHeaderStacks"] != null ?
                System.Web.HttpContext.Current.Session["RunInvoiceHeaderStacks"] as Dictionary<int, RunProformaInvoiceHeaderViewModel>
                : new Dictionary<int, RunProformaInvoiceHeaderViewModel>();
            
            var indexMax = runInvoiceHeaderStacks.Count();
            runInvoiceHeaderStacks.Add(++indexMax, viewModel);
            System.Web.HttpContext.Current.Session["RunInvoiceHeaderStacks"] = runInvoiceHeaderStacks;

            return Json(new {urlToRedirect = "CreateNew/" + indexMax}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEstimatedTime()
        {
            int rowNumber;
            try
            {
                rowNumber = WCFClientManager.SAPServiceClient.QueryTotalBillingRecords(UserManagementHelper.GetSessionId());
                return Json(new {estimatedTime = rowNumber/11}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
                return Json(new {estimatedTime = SharedResource.NA});
            }
        }

        /// <summary>
        /// GET: To create new proforma invoice from posted data stored in the temporary stack
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreateNew(int id)
        {
            var runInvoiceHeaderStacks = System.Web.HttpContext.Current.Session["RunInvoiceHeaderStacks"]
                as Dictionary<int, RunProformaInvoiceHeaderViewModel>;

            if (runInvoiceHeaderStacks == null) 
                return RedirectToAction("Index", "Error");

            PopulateCategories();

            var viewModel = runInvoiceHeaderStacks[id];
            return View(viewModel);
        }

        /// <summary>
        /// Asynchronus method to get Kendo Grid Datasource for Billing Items from DB
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult BillingItemsFromDB_Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<InvoiceProformaItemDTO> serviceModels;

            try
            {
                serviceModels = WCFClientManager.SAPServiceClient.QueryRunInvoiceBillingsAll(UserManagementHelper.GetSessionId());
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                ModelState.AddModelError("Name", ex.Message);
                return Json(ModelState.ToDataSourceResult());
            }

            // Map to the following model.
            var result = ProformaInvoiceHelper.GenerateBillingItemsViewModelJSON(request, serviceModels);
            var json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        /// <summary>
        /// Asynchronous method to retrieve proforma invoice items within one request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult BillingItems_ReadOnce([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<InvoiceProformaItemDTO> serviceModel;

            try
            {
                var user = UserManagementHelper.GetSessionId();
                serviceModel = WCFClientManager.SAPServiceClient.QueryRunInvoiceBillingsAll(user);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                ModelState.AddModelError("Name", ex.Message);
                return Json(ModelState.ToDataSourceResult());
            }

            var result = ProformaInvoiceHelper.GenerateBillingItemsViewModelJSON(request, serviceModel);
            var json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            
            return json;
        }

        /// <summary>
        /// Update Changes and Increase Version to SQL Server
        /// </summary>
        /// <param name="request"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BillingItems_Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<BillingItemViewModel> viewModel)
        {
            if (viewModel == null || !ModelState.IsValid)
                return Json(viewModel.ToDataSourceResult(request, ModelState));

            foreach (var model in viewModel)
            {
                try
                {
                    WCFClientManager.SAPServiceClient.UpdateRunInvoiceBilling(UserManagementHelper.GetSessionId(),
                        model.BillingItemId,
                        model.ReasonForRejectionVM.CategoryName == SharedResource.SpaceChar ||
                        model.ReasonForRejectionVM.CategoryName == ProformaInvoiceResource.PleaseSelectReasonForRejection ?
                        string.Empty : model.ReasonForRejectionVM.CategoryName, model.Remarks);
                }
                catch (Exception ex)
                {
                    ErrorSignal.FromCurrentContext().Raise(ex);
                    ModelState.AddModelError("Name", ex.Message);
                    return Json(ModelState.ToDataSourceResult());
                }
            }

            try
            {
                var newId = WCFClientManager.SAPServiceClient.SaveRunInvoiceBillings(UserManagementHelper.GetSessionId());
                System.Web.HttpContext.Current.Session["newBillingRunId"] = newId;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                ModelState.AddModelError("Name", ex.Message);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(viewModel.ToDataSourceResult(request, ModelState));
        }

        #region Common Parts
        
        /// <summary>
        /// Redirect after update changes
        /// </summary>
        /// <returns></returns>
        public ActionResult RedirectToBillingRun()
        {
            var newId = Convert.ToInt32(System.Web.HttpContext.Current.Session["newBillingRunId"] ?? "-1");
            return newId != -1
                ? RedirectToAction("Run", new { id = newId })
                : RedirectToAction("Index", "Error");
        }

        /// <summary>
        /// Initially save to DB when all data have been loaded
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveChanges()
        {
            try
            {
                WCFClientManager.SAPServiceClient.SaveInitialSAPData(UserManagementHelper.GetSessionId());
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(new
                {
                    messageToShow = ErrorResource.WCFCannotSave
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                messageToShow = string.Format(ProformaInvoiceResource.SaveAsDraftSuccessMessage)
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// GET SubmitToSAP triggered by Kendo Button.
        /// </summary>
        /// <returns></returns>
        public ActionResult SubmitToSAP()
        {
            var index = 0;
            // Save to DB First!
            try
            {
                WCFClientManager.SAPServiceClient.SaveRunInvoiceBillings(UserManagementHelper.GetSessionId());
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(new
                {
                    messageToShow = ErrorResource.WCFCannotSave,
                    urlToRedirect = "/Error?errorKey=WCFCannotSave"
                }, JsonRequestBehavior.AllowGet);
            }
            // Submit to SAP
            try
            {
                index = WCFClientManager.SAPServiceClient.SubmitInvoiceProforma(UserManagementHelper.GetSessionId()) ?? 0;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(new
                {
                    messageToShow = ErrorResource.WCFCannotSubmitToSAP,
                    urlToRedirect = "/Error?errorKey=WCFCannotSubmitToSAP"
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                messageToShow = string.Format(ProformaInvoiceResource.SubmitToSAPSucessMessage),
                urlToRedirect = string.Format("/ProformaInvoice/Run/{0}", index)
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Action result to generate Excel File from given kendo data source
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="base64"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            return File(fileContents, contentType, fileName);
        }

        /// <summary>
        /// Redirect to View CreateIncorrect 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateIncorrectExternalData()
        {
            var viewModel = ProformaInvoiceHelper.GenerateCreateIncorrectExternalDataViewModel();
            return View(viewModel);
        }

        /// <summary>
        /// Populate dropdownlist which is diplayed inside of Kendo Grid
        /// </summary>
        private void PopulateCategories()
        {
            var categories = ProformaInvoiceHelper.GenerateReasonForRejectionListViewModel()
                        .Select(c => new CategoryViewModel
                        {
                            CategoryID = c.CategoryID,
                            CategoryName = c.CategoryName
                        })
                        .OrderBy(e => e.CategoryID).Take(7);

            ViewData["categories"] = categories;
            ViewData["defaultCategory"] = categories.FirstOrDefault();
        }

        #endregion
    }
}