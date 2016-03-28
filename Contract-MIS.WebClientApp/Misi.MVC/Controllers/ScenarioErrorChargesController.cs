using System.Web.Mvc;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioErrorCharges;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ScenarioErrorChargesController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult CreateRequestInfo()
        {
            var viewModel = ScenarioErrorChargesHelper.GenerateRequestInfoViewModel();
            return View(viewModel);
        }

        public ActionResult CreateRoutingInfo()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.ErrorCharges);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateRoutingInfo(RoutingInfoWorkflowTableViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingInfoWorkflowTableViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.ErrorCharges);
                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service

            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult Preview()
        {
            var viewModel = ScenarioErrorChargesHelper.GeneratePreviewErrorChargesViewModel();
            return View(viewModel);
        }
    }
}