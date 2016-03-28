using System.Web.Mvc;
using Misi.MVC.Helpers;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ScenarioBrokenController : Controller
    {
        // GET: /ScenarioBroken/
        public ActionResult Index()
        {
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult CreateRequestInfo()
        {
            var viewModel = ScenarioBrokenHelper.GenerateRequestInfoViewModel();
            return View(viewModel);
        }

        public ActionResult Preview()
        {
            var viewModel = ScenarioBrokenHelper.GeneratePreviewBrokenViewModel();
            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult CreateRequestInfo(RequestInfoViewModel iModel)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", ErrorResources.FormFieldNotValid);
        //        iModel = (RequestInfoViewModel)
        //            ScenarioFormHelper.GenerateViewModel(ScenarioType.RequestInfoViewModel);

        //        return View(iModel);
        //    }

        //    return RedirectToAction("CreateRequestInfo");
        //}

        /// <summary>
        /// TODO: 1. Buat Action Result untuk Get 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateRoutingInfo()
        {
            //TODO: 2. Instansiasi view model dari Sub Scenario X
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.Broken);

            //TODO: 3. Parsing model ke View
            return View(viewModel);
        }
    }
}