using System.Web.Mvc;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ScenarioNewContractController : Controller
    {
        // GET: ScenarioNewContract
        public ActionResult Index()
        {
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult CreateRequestInfo()
        {
            var viewModel = ScenarioNewContractHelper.GenerateRequestInfoViewModel();
            return View(viewModel);
        }


        public ActionResult CreateRoutingInfoLDP()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractLDP);
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult CreateRoutingInfoLDP(RoutingTableViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingTableViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractLDP);

                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service

            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRequestInfoLDP");
        }

        public ActionResult CreateRoutingInfoIpPhoneExtLine()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractIpPhoneExtLine);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateRoutingInfoIpPhoneExtLine(RoutingTableViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingTableViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractIpPhoneExtLine);
                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service

            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRequestInfoLDP");
        }

        public ActionResult CreateRoutingInfoIpPhone()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractIPPhone);
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult CreateRoutingInfoIpPhone(RoutingTableViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingTableViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractIPPhone);

                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service

            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRequestInfoLDP");
        }

        public ActionResult CreateRoutingInfoExtLine()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractExtLine);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateRoutingInfoExtLine(RoutingTableViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingTableViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractExtLine);

                return View(iModel);
            }
            return RedirectToAction("CreateRequestInfoLDP");
        }

        public ActionResult CreateRoutingInfoSoftware()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractSoftware);
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult CreateRoutingInfoSoftware(RoutingTableViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingTableViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.NewContractSoftware);

                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service


            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRequestInfoLDP");
        }

        public ActionResult Preview()
        {
            var viewModel = ScenarioNewContractHelper.GeneratePreviewNewContractViewModel();
            return View(viewModel);
        }
    }
}