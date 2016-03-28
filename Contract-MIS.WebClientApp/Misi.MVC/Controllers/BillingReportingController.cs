using System;
using System.IO;
using System.Web.Mvc;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Misi.DocumentManagement.PDFGeneration.Service.Reporting;
using Misi.MVC.Filters;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.SAPServiceClient;
using Misi.MVC.ServiceClient;
using Misi.MVC.ViewModels.BillingReporting;
using PopupBillingDocumentViewModel = Misi.MVC.ViewModels.BillingReporting.PopupBillingDocumentViewModel;

//using PopupBillingDocumentViewModel = Misi.MVC.ViewModels.BillingReporting.PopupBillingDocumentViewModel;

namespace Misi.MVC.Controllers
{
    [Filters.HandleError]
    [ADSAPAuthorize]
    public class BillingReportingController : Controller
    {
        //private RunPrintBillingsDTO serviceModelHeader;

        private readonly IPDFConverter _pdfConverter;

        public BillingReportingController()
        {
            _pdfConverter = new PDFConverter();
        }


        //
        // GET: /BillingReport/
        public ActionResult Index()
        {
            return RedirectToAction("MSTInvoice");
        }

        public ActionResult MSTInvoice()
        {
            MSTInvoiceBillingReportingViewModel viewModel =
                BillingReportingHelper.GenerateMSTInvoiceBillingReportingViewModel();
            return View(viewModel);
        }

        public ActionResult BillingServiceRequest()
        {
            var viewModel = BillingReportingHelper.GenerateBillingServiceRequestViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult BillingServiceRequest(BillingServiceRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                viewModel = BillingReportingHelper.GenerateBillingServiceRequestViewModel();
                return View(viewModel);
            }

            viewModel = BillingReportingHelper.GenerateBillingServiceRequestViewModel();
            return View(viewModel);
        }


        public ActionResult GenerateInvoice(string bilDoc)
        {
            RunPrintBillingsDTO serviceModel;

            try
            {
                serviceModel =
                    WCFClientManager.SAPServiceClient.GetBillingsToPrintTotal(UserManagementHelper.GetSessionId(),
                        bilDoc) as RunPrintBillingsDTO;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return RedirectToAction("Index", "Error");
            }
            ReportInvoiceViewModel invoiceViewModel = BillingReportingHelper.GenerateInvoiceViewModel(serviceModel);
            HeaderInvoice(bilDoc);
            return GenerateInvoicePdf(invoiceViewModel, bilDoc);
        }


        public ActionResult GenerateInvoiceDetail(string bilDoc)
        {
            RunPrintBillingsDTO serviceModel;

            try
            {
                serviceModel =
                    WCFClientManager.SAPServiceClient.GetBillingsToPrint(UserManagementHelper.GetSessionId(), bilDoc) as
                        RunPrintBillingsDTO;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return RedirectToAction("Index", "Error");
            }

            ReportInvoiceDetailViewModel invoiceDetailViewModel =
                BillingReportingHelper.GenerateInvoiceDetailViewModel(serviceModel);
            return GenerateInvoiceDetailPdf(invoiceDetailViewModel);
        }


        /// <summary>
        /// Original File
        /// </summary>
        /// <param name="reportInvoiceViewModel"></param>
        /// <returns></returns>
        public ActionResult GenerateInvoicePdf(ReportInvoiceViewModel reportInvoiceViewModel, string bilDoc)
        {
            // refers to master page of report
            const string relativePath = "~/Views/BillingReporting/Invoice.cshtml";
            string content;

            //get hostName
            //var hostName = Request.Url.GetLeftPart(UriPartial.Authority) + "/";

            var view = ViewEngines.Engines.FindView(ControllerContext, relativePath, null);

            SAPServiceClient.RunPrintBillingsDTO serviceModel = null;
            // for displaying view models
            //ViewData.Model = BillingReportingHelper.GenerateReportInvoiceViewModel();
            ViewData.Model = reportInvoiceViewModel;
            //HeaderInvoice(bilDoc);

            using (var writer = new StringWriter())
            {
                var context = new ViewContext(ControllerContext, view.View, ViewData, TempData, writer);
                view.View.Render(context, writer);
                writer.Flush();
                content = writer.ToString();
                byte[] pdfBuf = _pdfConverter.Convert(content, Server.MapPath("~/App_Data/"));
                if (pdfBuf == null)
                    return HttpNotFound();
                return File(pdfBuf, "application/pdf");
            }
        }

        /// <summary>
        /// Return a PDF File from given view model
        /// View : Views/BillingReport/Invoice.cshtml
        /// </summary>
        /// <param name="reportInvoiceDetailViewModel"></param>
        /// <returns></returns>
        public ActionResult GenerateInvoiceDetailPdf(ReportInvoiceDetailViewModel reportInvoiceDetailViewModel)
        {
            // refers to master page of report
            const string relativePath = "~/Views/BillingReporting/InvoiceDetail.cshtml";
            string content;
            //get hostName
            //var hostName = Request.Url.GetLeftPart(UriPartial.Authority) + "/";

            var view = ViewEngines.Engines.FindView(ControllerContext, relativePath, null);

            //SAPServiceClient.RunPrintBillingsDTO serviceModel = null;
            // for displaying view models
            ViewData.Model = reportInvoiceDetailViewModel;

            using (var writer = new StringWriter())
            {
                var context = new ViewContext(ControllerContext, view.View, ViewData, TempData, writer);
                view.View.Render(context, writer);
                writer.Flush();
                content = writer.ToString();
                byte[] pdfBuf = _pdfConverter.ConvertDetail(content, Server.MapPath("~/App_Data/"));
                if (pdfBuf == null)
                    return HttpNotFound();
                return File(pdfBuf, "application/pdf");
            }
        }

        public ActionResult DetailSubMaterialDescription()
        {
            RunPrintBillingsDTO serviceModel = null;

            try
            {
                serviceModel =
                    WCFClientManager.SAPServiceClient.GetBillingsToPrint(UserManagementHelper.GetSessionId(),
                        "1960007091") as RunPrintBillingsDTO;
            }
            catch (Exception)
            {
                var mockedServiceModel = BillingReportingHelper.GenerateMockedInvoiceDetailViewModel();
                var mock = BillingReportingHelper.GenerateInvoiceViewModel(mockedServiceModel);
                return View(mock);
            }

            var viewModel = BillingReportingHelper.GenerateInvoiceViewModel(serviceModel);
            return View(viewModel);

            //return RedirectToAction("GenerateInvoice");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult BillingDocument(MSTInvoiceBillingReportingViewModel iModel)
        {
            BillingNumberItemDTO[] billingNumber;
            try
            {
                var dateFrom = DictionaryHelper.KendoDatePickerDateStringToDateTime(iModel.DateFromValue);
                var dateTo = DictionaryHelper.KendoDatePickerDateStringToDateTime(iModel.DateToValue);
                billingNumber =
                    WCFClientManager.SAPServiceClient.QueryBillingNumbers(UserManagementHelper.GetSessionId(),
                        iModel.SoldToFromValue, dateFrom, dateTo);
            }
            catch (Exception)
            {
                return Json(new {html = ErrorResource.WCFCannotGetObjectHTML});
            }

            var viewModel = BillingReportingHelper.GeneratePopupBillingDocumentViewModel(billingNumber, iModel);
            var renderedHtml = ViewHelper.RenderPartialViewToString(this, "_PartialPopupBillingDocumentListBilling",
                viewModel);
            return Json(new {html = renderedHtml});
        }

        [HttpPost]
        public ActionResult MSTInvoice(PopupBillingDocumentViewModel iModel)
        {
            var viewModel = BillingReportingHelper.GenerateMSTInvoiceBillingReportingViewModel(iModel);
            return View(viewModel);
        }

        public ActionResult Appendix(string bilDoc)
        {
            ViewBag.bilDoc = bilDoc;
            return View();
        }

        public ActionResult AppendixItems_Read([DataSourceRequest] DataSourceRequest request, string bilDoc)
        {
            Contract serviceModel;
            try
            {
                serviceModel =
                    WCFClientManager.SAPServiceClient.GetBillingsToPrintAppendix(UserManagementHelper.GetSessionId(),
                        bilDoc) as Contract;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(JsonRequestBehavior.AllowGet);
            }

            var viewModel = BillingReportingHelper.GenerateBillingItemsViewModel(serviceModel);
       
            var result = viewModel.AppendixTableViewModels.ToDataSourceResult(request);
            var json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;

            return json;


           
        }

        //export to excel
        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            return File(fileContents, contentType, fileName);
        }

        public ActionResult PreviewAppendix(string bilDoc)
        {
            RunPrintBillingsDTO serviceModel;

            try
            {
                serviceModel =
                    WCFClientManager.SAPServiceClient.GetBillingsToPrintAppendix(UserManagementHelper.GetSessionId(),
                        bilDoc) as RunPrintBillingsDTO;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                RedirectToAction("Index", "Error");
            }

            return View("Appendix");
        }


        //header untuk HeaderInvoice Total
        public ActionResult HeaderInvoice(string bilDoc)
        {
            RunPrintBillingsDTO serviceModel;

            try
            {
                serviceModel =
                    WCFClientManager.SAPServiceClient.GetBillingsToPrintTotal(UserManagementHelper.GetSessionId(),
                        bilDoc) as RunPrintBillingsDTO;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return RedirectToAction("Index", "Error");
            }

            ReportInvoiceViewModel reportInvoiceViewModel = BillingReportingHelper.GenerateInvoiceViewModel(serviceModel);
            return View(reportInvoiceViewModel);
        }

        //header untuk HeaderInvoiceDetail 
        //public ActionResult HeaderInvoiceDetail(string bilDoc)
        //{
        //    RunPrintBillingsDTO serviceModel; 

        //    try
        //    {
        //        serviceModel = WCFClientManager.SAPServiceClient.GetBillingsToPrintTotal(ConfigResource.DefaultUser, bilDoc) as RunPrintBillingsDTO;
        //    }
        //    catch (Exception)
        //    {
        //        //var mockedServiceModel = BillingReportingHelper.GenerateMockedInvoiceDetailViewModel();
        //        //var mock = BillingReportingHelper.Generat(mockedServiceModel);
        //        //return View(mock);
        //        //return GenerateInvoicePdf(mock, bilDoc);

        //        //return GenerateInvoiceDetailPdf(BillingReportingHelper.GenerateInvoiceDetailViewModel(), bilDoc);
        //        return RedirectToAction("Error", "Home");
        //    }

        //    HeaderInoviceDetailViewModel headerInoviceDetailViewModel = BillingReportingHelper.GenerateHeaderInvoiceDetailViewModel(serviceModel);
        //    return View(headerInoviceDetailViewModel);

        //}


        //public ActionResult HeaderInvoiceDetailFromSap(string bilDoc, string payerName, string currency, string headerNote)
        //{
        //    RunInvoiceBillingsDTO serviceModel = new RunInvoiceBillingsDTO();
        //    HeaderInoviceDetailViewModel headerInvoiceDetailViewModel = new HeaderInoviceDetailViewModel()
        //    {
        //        Currency = currency,
        //        HeaderNote = headerNote,
        //        PayerName = payerName,
        //        InvoiceNo = bilDoc
        //    };
        //    return View("HeaderInvoiceDetail", headerInvoiceDetailViewModel);
        //}

        //public void HeaderInvoiceDetailFromSap(string bilDoc)
        //{
        //    RunPrintBillingsDTO serviceModelHeader = new RunPrintBillingsDTO(); 
        //    try
        //    {

        //        serviceModelHeader= WCFClientManager.SAPServiceClient.GetBillingsToPrintTotal(ConfigResource.DefaultUser, bilDoc) as RunPrintBillingsDTO;
        //    }
        //    catch (Exception)
        //    {
        //        //var mockedServiceModel = BillingReportingHelper.GenerateMockedInvoiceDetailViewModel();
        //        //var mock = BillingReportingHelper.Generat(mockedServiceModel);
        //        //return View(mock);
        //        //return GenerateInvoicePdf(mock, bilDoc);
        //        GenerateInvoiceDetailPdf(BillingReportingHelper.GenerateInvoiceDetailViewModel(), bilDoc);
        //    }

        //    //string PayerName = serviceModelHeader._printBillingHeader.NAME1;
        //    //string Currency = serviceModelHeader._printBillingHeader.WAERK;
        //    //string HeaderNote = serviceModelHeader._printBillingHeader.TDLINE;
        //    //string InvoiceNo = serviceModelHeader._printBillingHeader.VBELN;
        //    //Response.Cookies["PayerName"].Value = PayerName;
        //    //Response.Cookies["Currency"].Value = Currency;
        //    //Response.Cookies["HeaderNote"].Value = HeaderNote;
        //    //Response.Cookies["InvoiceNo"].Value = InvoiceNo;

        //    //Response.Cookies["PayerName"].Expires = DateTime.Now.AddDays(1);
        //    //Response.Cookies["Currency"].Expires = DateTime.Now.AddDays(1);
        //    //Response.Cookies["HeaderNote"].Expires = DateTime.Now.AddDays(1);
        //    //Response.Cookies["InvoiceNo"].Expires = DateTime.Now.AddDays(1);


        //}
    }
}