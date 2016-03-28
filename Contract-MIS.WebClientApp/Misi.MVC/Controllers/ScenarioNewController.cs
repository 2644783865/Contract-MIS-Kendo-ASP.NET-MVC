using System.Web.Mvc;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioNew;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ScenarioNewController : Controller
    {
        //
        // GET: /ScenarioNew/
        public ActionResult Index()
        {
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult CreateRequestInfo()
        {
            var viewModel = ScenarioNewHelper.GenerateRequestInfoViewModel();
            return View(viewModel);
        }

        public ActionResult Preview()
        {
            var viewModel = ScenarioNewHelper.GeneratePreviewNewViewModel();
            return View();
        }

        //[HttpPost]
        //public ActionResult CreateRequestInfo(RequestInfoHeadingViewModel iModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", ErrorResources.FormFieldNotValid);
        //        iModel = (RequestInfoHeadingViewModel)ScenarioFormHelper.GenerateViewModel(ScenarioType.RequestInfoHeadingViewModel);
        //        return View(iModel);
        //    }

        //    // pemrosesan ke WCF 

        //    return RedirectToAction("CreateRequestInfo", "ScenarioNew");
        //}

        /// <summary>
        /// TODO: 1. Buat Action Result untuk Get 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateRoutingInfo()
        {
            //TODO: 2. Instansiasi view model dari Sub Scenario X
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.ScenarioNew);

            //TODO: 3. Parsing model ke View
            return View(viewModel);
        }

        /// <summary>
        /// TODO: 4. Setelah View untuk form disiapkan, buat Action Result untuk Post
        /// Beri nama yang SAMA dengan fungsi GET
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateRoutingInfo(RoutingInfoNewScenarioViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingInfoNewScenarioViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.ScenarioNew);

                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service

            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRoutingInfo");
        }
    }
}