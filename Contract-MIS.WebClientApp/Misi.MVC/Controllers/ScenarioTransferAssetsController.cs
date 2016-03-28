using System.Web.Mvc;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioTransferAssets;


namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ScenarioTransferAssetsController : Controller
    {
        //
        // GET: /ScenarioTransferAssets/
        public ActionResult Index()
        {
            //harus redirect to action reateRequesst Info(dibuat dulu view model dan controller
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult CreateRequestInfo()
        {
            var viewModel = ScenarioTransferAssetsHelper.GenerateRequestInfoViewModel();
            return View(viewModel);
        }

        public ActionResult Preview()
        {
            var viewModel = ScenarioTransferAssetsHelper.GeneratePreviewTransferAssetsViewModel();
            return View(viewModel);
        }

        public ActionResult CreateRoutingInfoLocation()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.TransferAssetsLocation);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateRoutingInfoLocation(RoutingInfoLocationViewModel iModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel =
                    (RoutingInfoLocationViewModel)
                        ScenarioFormHelper.GenerateViewModel(ScenarioType.TransferAssetsLocation);
                return View(iModel);
            }

            return RedirectToAction("About", "Home");
        }


        public ActionResult CreateRoutingInfoHolder()
        {
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.TransferAssetsHolder);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateRoutingInfoHolder(RoutingInfoHolderViewModel iModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel =
                    (RoutingInfoHolderViewModel) ScenarioFormHelper.GenerateViewModel(ScenarioType.TransferAssetsHolder);
                return View(iModel);
            }

            //process to WCF

            return RedirectToAction("CreateRoutingInfoHolder");
        }
    }
}