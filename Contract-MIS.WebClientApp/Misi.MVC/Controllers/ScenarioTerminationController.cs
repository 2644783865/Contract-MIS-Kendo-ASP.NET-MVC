using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Kendo.Mvc.UI;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;
using Misi.MVC.ViewModels.ScenarioTermination;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ScenarioTerminationController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult CreateRequestInfo()
        {
            var viewModel = ScenarioTerminationHelper.GenerateRequestInfoViewModel();
            return View(viewModel);
        }

        public ActionResult CreateRoutingInfo()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.Termination);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateRoutingInfo(RoutingTableViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingTableViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.Termination);
                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service

            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult Preview()
        {
            var viewModel = ScenarioTerminationHelper.GeneratePreviewTerminationViewModel();
            return View(viewModel);
        }

        public ActionResult PreviewRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(new List<PreviewRequestInfoTableViewModel>
            {
                new PreviewRequestInfoTableViewModel
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
                
            },JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        /// <summary>
        /// Method for Save Upload FIle with Kendo
        /// </summary>
        /// <param name=files></param>
        /// <returns></returns>
        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // The files are not actually saved in this demo
                    file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        /// <summary>
        /// Method for Remove File Upload
        /// </summary>
        /// <param name=fileNames></param>
        /// <returns></returns>
        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
    }
}