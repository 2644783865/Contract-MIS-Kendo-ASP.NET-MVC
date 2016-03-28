using System;
using System.Linq;
using System.Web.Mvc;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ServiceRequest;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ServiceRequestController : Controller
    {
        // GET: ServiceRequest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = ServiceRequestHelper.GenerateCreateServiceRequestViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateServiceRequestViewModel iModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = ServiceRequestHelper.GenerateCreateServiceRequestViewModel();
                return View(iModel);
            }

            var chosenScenarioTupple = GenerateScenarioTupple(iModel.Scenarios.PostData);
            return RedirectToAction(chosenScenarioTupple.Item1, chosenScenarioTupple.Item2);
        }

        private Tuple<string, string> GenerateScenarioTupple(string chosenScenario)
        {
            if (chosenScenario == ServiceRequestHelper.cNewContractScenario)
            {
                return new Tuple<string, string>("CreateRequestInfo", "ScenarioNewContract");
            }
            if (chosenScenario == ServiceRequestHelper.cTransferAssetsScenario)
            {
                return new Tuple<string, string>("CreateRequestInfo", "ScenarioTransferAssets");
            }
            if (chosenScenario == ServiceRequestHelper.cBroken)
            {
                return new Tuple<string, string>("CreateRequestInfo", "ScenarioBroken");
            }
            if (chosenScenario == ServiceRequestHelper.cErrorChargesScenario)
            {
                return new Tuple<string, string>("CreateRequestInfo", "ScenarioErrorCharges");
            }

            if (chosenScenario == ServiceRequestHelper.cNewScenario)
            {
                return new Tuple<string, string>("CreateRequestInfo", "ScenarioNew");
            }
            if (chosenScenario == ServiceRequestHelper.cReturnDevice)
            {
                return new Tuple<string, string>("CreateRequestInfo", "ScenarioReturnDevice");
            }
            if (chosenScenario == ServiceRequestHelper.cTerminationScenario)
            {
                return new Tuple<string, string>("CreateRequestInfo", "ScenarioTermination");
            }
            return new Tuple<string, string>("Create", "ServiceRequest");
        }

        public ActionResult Maintain()
        {
            var viewModel = ServiceRequestHelper.GenerateMaintainServiceRequestViewModel();

            return View(viewModel);
        }
    }
}